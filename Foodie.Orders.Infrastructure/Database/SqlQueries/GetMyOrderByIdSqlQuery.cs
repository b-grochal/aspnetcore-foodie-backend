using AutoMapper;
using Dapper;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Database.SqlQueries;
using Foodie.Orders.Application.Features.Orders.Queries.GetCustomersOrderById;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Database.SqlQueries
{
    public class GetMyOrderByIdSqlQuery : IGetMyOrderByIdSqlQuery
    {
        private readonly IDbConnecionFactory _dbConnectionFactory;

        public GetMyOrderByIdSqlQuery(IDbConnecionFactory dapperContext)
        {
            _dbConnectionFactory = dapperContext;
        }

        public async Task<GetMyOrderByIdQueryResponse> ExecuteAsync(GetMyOrderByIdQuery query)
        {
            var selector = PrepareSqlQueryTemplate(query.Id, query.ApplicationUserId);

            using var connection = _dbConnectionFactory.CreateConnection();
            connection.Open();

            var ordersMap = new Dictionary<int, OrderDetailsQueryDto>();

            var sqlQueryResult = await connection.QueryAsync<OrderDetailsQueryDto, OrderItemQueryDto, OrderDetailsQueryDto>(selector.RawSql, param: selector.Parameters,
                map: (orderDetails, orderItem) =>
                {
                    if (ordersMap.TryGetValue(orderDetails.OrderId, out OrderDetailsQueryDto existingOrder))
                    {
                        orderDetails = existingOrder;
                    }
                    else
                    {
                        orderDetails.OrderItems = new List<OrderItemQueryDto>();
                        ordersMap.Add(orderDetails.OrderId, orderDetails);
                    }

                    orderDetails.OrderItems.Add(orderItem);
                    return orderDetails;
                },
                splitOn: "OrderItemId");

            var firstResult = sqlQueryResult.FirstOrDefault();

            return firstResult is not null ? MapSqlQueryResult(firstResult) : null;
        }

        private Template PrepareSqlQueryTemplate(int orderId, int customerId)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("select /**select**/ from orders o /**innerjoin**/ /**where**/");

            builder.Select("""
                o.Id as OrderId,
                o.DeliveryAddress_Street as AddressStreet,
                o.DeliveryAddress_City as AddressCity,            
                o.DeliveryAddress_Country as AddressCountry,
                o.OrderStatus as OrderStatus,
                b.Id as BuyerId,
                b.FirstName as BuyerFirstName,
                b.LastName as BuyerLastName,
                b.PhoneNumber as BuyerPhoneNumber,
                b.Email as BuyerEmail,
                c.Id as ContractorId,
                c.Name as ContractorName,
                c.Address as ContractorAddress,
                c.PhoneNumber as ContractorPhoneNumber,
                c.Email as ContractorEmail,
                c.City as ContractorCity,
                c.Country as ContractorCountry, 
                oi.Id as OrderItemId, 
                oi.Name as Name, 
                oi.Quantity as Quantity, 
                oi.UnitPrice as UnitPrice
                """);

            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.InnerJoin("OrderItems oi on o.Id = oi.OrderId");
            builder.Where("o.Id = @orderId", new { orderId });
            builder.Where("b.CustomerId = @customerId", new { customerId });

            return selector;
        }

        private GetMyOrderByIdQueryResponse MapSqlQueryResult(OrderDetailsQueryDto data)
        {
            return new GetMyOrderByIdQueryResponse
            {
                Id = data.OrderId,
                AddressStreet = data.AddressStreet,
                AddressCity = data.AddressCity,
                AddressCountry = data.AddressCountry,
                OrderStatus = data.OrderStatus,
                ContractorId = data.ContractorId,
                ContractorName = data.ContractorName,
                ContractorAddress = data.ContractorAddress,
                ContractorPhoneNumber = data.ContractorPhoneNumber,
                ContractorEmail = data.ContractorEmail,
                ContractorCity = data.ContractorCity,
                ContractorCountry = data.ContractorCountry,
                Items = data.OrderItems.Select(x => new MyOrderItemDto
                {
                    Id = x.OrderItemId,
                    Name = x.Name,
                    Quantity = x.Quantity,
                    UnitPrice = x.UnitPrice
                }).ToList()
            };
        }

        class OrderDetailsQueryDto
        {
            public int OrderId { get; set; }
            public string AddressStreet { get; set; }
            public string AddressCity { get; set; }
            public string AddressCountry { get; set; }
            public string OrderStatus { get; set; }
            public int BuyerId { get; set; }
            public string BuyerFirstName { get; set; }
            public string BuyerLastName { get; set; }
            public string BuyerPhoneNumber { get; set; }
            public string BuyerEmail { get; set; }
            public int ContractorId { get; set; }
            public string ContractorName { get; set; }
            public string ContractorAddress { get; set; }
            public string ContractorPhoneNumber { get; set; }
            public string ContractorEmail { get; set; }
            public string ContractorCity { get; set; }
            public string ContractorCountry { get; set; }
            public IList<OrderItemQueryDto> OrderItems { get; set; }
        }

        class OrderItemQueryDto
        {
            public int OrderItemId { get; set; }
            public string Name { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
        }
    }
}
