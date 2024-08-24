using Dapper;
using Foodie.Common.Collections;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries;
using Foodie.Orders.Application.Features.Orders.Queries.GetOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Database.SqlQueries
{
    public class GetOrdersSqlQuery : IGetOrdersSqlQuery
    {
        private readonly IDbConnecionFactory _dbConnecionFactory;

        public GetOrdersSqlQuery(IDbConnecionFactory dbConnecionFactory)
        {
            _dbConnecionFactory = dbConnecionFactory;
        }

        public async Task<GetOrdersQueryResponse> ExecuteAsync(GetOrdersQuery query)
        {
            var selector = PrepareSqlQueryTemplate(query.PageNumber, query.PageSize, query.BuyerEmail, query.OrderStatus, query.ContractorName, query.LocationId);

            using var dbConnection = _dbConnecionFactory.CreateConnection();

            dbConnection.Open();

            var orders = await dbConnection.QueryAsync<OrderQueryDto>(selector.RawSql, selector.Parameters);
            return MapSqlQueryResult(orders, query.PageNumber, query.PageSize, query.BuyerEmail, query.OrderStatus, query.ContractorName, query.LocationId);
        }

        private Template PrepareSqlQueryTemplate(int pageNumber, int pageSize, string buyerEmail, string orderStatus, string contractorName, int? locationId)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("""
                Select /**select**/ 
                from orders o 
                /**innerjoin**/ 
                /**where**/ 
                /**orderby**/ 
                offset @offset 
                rows fetch next @pageSize 
                rows only
                """,
                new { offset = (pageNumber - 1) * pageSize, pageSize });

            builder.Select("""
                    o.Id as Id, 
                    o.OrderStatus as OrderStatus, 
                    b.Id as BuyerId,
                    b.Email as BuyerEmail, 
                    c.Id as ContractorId, 
                    c.Name as ContractorName
                    """);

            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.OrderBy("o.Id desc");

            if (buyerEmail != null)
                builder.Where("b.Email = @buyerEmail", new { buyerEmail });

            if (orderStatus != null)
                builder.Where("o.OrderStatus = @orderStatus", new { orderStatus });

            if (contractorName != null)
                builder.Where("c.Name like @contractorName", new { contractorName = $"%{contractorName}%" });

            if (locationId.HasValue)
                builder.Where("c.LocationId = @locationId", new { locationId = locationId.Value });

            return selector;
        }

        private GetOrdersQueryResponse MapSqlQueryResult(IEnumerable<OrderQueryDto> data, int pageNumber, int pageSize, string buyerEmail, string orderStatus, string contractorName, int? locationId)
        {
            var orders = PagedList<OrderQueryDto>.Create(data, pageNumber, pageSize);

            return new GetOrdersQueryResponse
            {
                TotalCount = orders.TotalCount,
                PageSize = orders.PageSize,
                Page = orders.Page,
                TotalPages = (int)Math.Ceiling(orders.TotalCount / (double)orders.PageSize),
                Orders = orders.Items.Select(x => new OrderDto
                {
                    Id = x.Id,
                    OrderStatus = x.OrderStatus,
                    BuyerId = x.BuyerId,
                    BuyerEmail = x.BuyerEmail,
                    ContractorId = x.ContractorId,
                    ContactorName = x.ContractorName
                }),
                BuyerEmail = buyerEmail,
                OrderStatus = orderStatus,
                ContractorName = contractorName
            };
        }

        class OrderQueryDto
        {
            public int Id { get; set; }
            public string OrderStatus { get; set; }
            public int BuyerId { get; set; }
            public string BuyerEmail { get; set; }
            public int ContractorId { get; set; }
            public string ContractorName { get; set; }
        }
    }
}
