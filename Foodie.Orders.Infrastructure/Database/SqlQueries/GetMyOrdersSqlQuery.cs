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
            var countQuery = PrepareCountSqlQuery(query.ApplicationUserId, query.OrderStatus, query.ContractorName);

            using var dbConnection = _dbConnecionFactory.CreateConnection();

            dbConnection.Open();

            var orders = await dbConnection.QueryAsync<MyOrderQueryDto>(selector.RawSql, selector.Parameters);
            var totalCount = await dbConnection.ExecuteScalarAsync<int>(countQuery.RawSql, countQuery.Parameters);

            return MapSqlQueryResult(orders, query.PageNumber, query.PageSize, query.OrderStatus, query.ContractorName, totalCount);
        }

        private Template PrepareSqlQueryTemplate(int pageNumber, int pageSize, int customerId, string orderStatus, string contractorName)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate(
                """
                Select /**select**/ 
                from orders o 
                /**innerjoin**/ 
                /**leftjoin**/
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
                o.Id as Id, 
                o.OrderStatus as OrderStatus, 
                b.Id as BuyerId, 
                b.Email as BuyerEmail, 
                c.Id as ContractorId, 
                c.Name as ContractorName,
                a.ModificationDate as CreatedDate
                """);

            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.LeftJoin("Audits a on json_value(a.PrimaryKey, '$.Id') = o.Id and a.Type = 1 and a.TableName = 'Order'");
            builder.OrderBy("o.Id desc");
            builder.Where("b.CustomerId = @customerId", new { customerId });

            if (orderStatus != null)
                builder.Where("o.OrderStatus = @orderStatus", new { orderStatus });

            if (contractorName != null)
                builder.Where("c.Name like @contractorName", new { contractorName = $"%{contractorName}%" });

            return selector;
        }

        private Template PrepareCountSqlQuery(int customerId, string orderStatus, string contractorName)
        {
            var builder = new SqlBuilder();

            var countQuery = builder.AddTemplate(
                """
                    SELECT COUNT(*)
                    FROM orders o
                    /**innerjoin**/
                    /**where**/
                    """);

            builder.InnerJoin("Buyers b ON o.BuyerId = b.Id");
            builder.Where("b.CustomerId = @customerId", new { customerId });

            if (!string.IsNullOrEmpty(orderStatus))
            {
                builder.Where("o.OrderStatus = @orderStatus", new { orderStatus });
            }

            if (!string.IsNullOrEmpty(contractorName))
            {
                builder.Where("c.Name LIKE @contractorName", new { contractorName = $"%{contractorName}%" });
            }

            return countQuery;
        }

        private GetMyOrdersQueryResponse MapSqlQueryResult(IEnumerable<MyOrderQueryDto> data, int pageNumber, int pageSize, string orderStatus, string contractorName, int totalCount)
        {
            var orders = PagedList<MyOrderQueryDto>.Create(data, pageNumber, pageSize);

            return new GetMyOrdersQueryResponse
            {
                TotalCount = totalCount,
                PageSize = orders.PageSize,
                Page = orders.Page,
                TotalPages = (int)Math.Ceiling(orders.TotalCount / (double)orders.PageSize),
                Items = orders.Items.Select(x => new MyOrderDto
                {
                    Id = x.Id,
                    OrderStatus = x.OrderStatus,
                    ContractorId = x.ContractorId,
                    ContractorName = x.ContractorName,
                    CreatedDate = x.CreatedDate
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
            public DateTimeOffset CreatedDate { get; set; }
        }
    }
}
