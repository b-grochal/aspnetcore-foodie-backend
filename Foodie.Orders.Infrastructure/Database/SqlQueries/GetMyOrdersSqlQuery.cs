using Dapper;
using Foodie.Common.Collections;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrders;
using Foodie.Orders.Application.Features.Orders.Queries.GetOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Database.SqlQueries
{
    public class GetMyOrdersSqlQuery : IGetMyOrdersSqlQuery
    {
        private readonly IDbConnecionFactory _dbConnecionFactory;

        public GetMyOrdersSqlQuery(IDbConnecionFactory dbConnecionFactory)
        {
            _dbConnecionFactory = dbConnecionFactory;
        }

        public async Task<GetMyOrdersQueryResponse> ExecuteAsync(GetMyOrdersQuery query)
        {
            var selector = PrepareSqlQueryTemplate(query.PageNumber, query.PageSize, query.ApplicationUserId, query.OrderStatus, query.ContractorName);

            using var dbConnection = _dbConnecionFactory.CreateConnection();

            dbConnection.Open();

            var orders = await dbConnection.QueryAsync<MyOrderQueryDto>(selector.RawSql, selector.Parameters);
            return MapSqlQueryResult(orders, query.PageNumber, query.PageSize, query.OrderStatus, query.ContractorName);
        }

        private Template PrepareSqlQueryTemplate(int pageNumber, int pageSize, int customerId, string orderStatus, string contractorName)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate(
                """
                Select /**select**/ 
                from orders o 
                /**innerjoin**/ 
                /**where**/ 
                /**orderby**/ 
                offset @offset 
                rows fetch 
                next @pageSize 
                rows only
                """
                , new { offset = (pageNumber - 1) * pageSize, pageSize });

            builder.Select(
                """
                o.Id as OrderId, 
                o.OrderStatus as OrderStatus, 
                b.Id as BuyerId, 
                b.Email as BuyerEmail, 
                c.Id as ContractorId, 
                c.Name as ContractorName
                """);

            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.OrderBy("o.Id desc");
            builder.Where("b.CustomerId = @customerId", new { customerId });

            if (orderStatus != null)
                builder.Where("o.OrderStatus = @orderStatus", new { orderStatus });

            if (contractorName != null)
                builder.Where("c.Name like @contractorName", new { contractorName = $"%{contractorName}%" });

            return selector;
        }

        private GetMyOrdersQueryResponse MapSqlQueryResult(IEnumerable<MyOrderQueryDto> data, int pageNumber, int pageSize, string orderStatus, string contractorName)
        {
            var orders = PagedList<MyOrderQueryDto>.Create(data, pageNumber, pageSize);

            return new GetMyOrdersQueryResponse
            {
                TotalCount = orders.TotalCount,
                PageSize = orders.PageSize,
                Page = orders.Page,
                TotalPages = (int)Math.Ceiling(orders.TotalCount / (double)orders.PageSize),
                Items = orders.Items.Select(x => new MyOrderDto
                {
                    Id = x.Id,
                    OrderStatus = x.OrderStatus,
                    ContractorId = x.ContractorId,
                    ContractorName = x.ContractorName
                }),
                OrderStatus = orderStatus,
                ContractorName = contractorName
            };
        }

        class MyOrderQueryDto
        {
            public int Id { get; set; }
            public string OrderStatus { get; set; }
            public int ContractorId { get; set; }
            public string ContractorName { get; set; }
        }
    }
}
