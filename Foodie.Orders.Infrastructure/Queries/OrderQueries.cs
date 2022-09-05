using Dapper;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries;
using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using Foodie.Orders.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Queries
{
    public class OrderQueries : IOrderQueries
    {
        private readonly DapperContext _dapperContext;

        public OrderQueries(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<OrderDto>> GetAllAsync(string buyerEmail, string orderStatusName, string contractorName, int pageNumber, int pageSize)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from orders o /**innerjoin**/ /**where**/ /**orderby**/ offset @offset rows fetch next @pageSize rows only", new { offset = (pageNumber-1)*pageSize, pageSize} );

            builder.Select("o.Id as OrderId, o.OrderDate as OrderDate, os.Id as OrderStatusId, os.Name as OrderStatusName, b.Id as BuyerId, b.Email as BuyerEmail, c.Id as ContractorId, c.Name as ContractorName");
            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.InnerJoin("OrderStatuses os on o.OrderStatusId = os.Id");
            
            if (buyerEmail != null)
                builder.Where("b.Email = @buyerEmail", new { buyerEmail });

            if (orderStatusName != null)
                builder.Where("os.Name= @orderStatusName", new { orderStatusName });

            if (contractorName != null)
                builder.Where("os.Name= @orderStatusName", new { orderStatusName });

            using var connection = _dapperContext.CreateConnection();
            connection.Open();

            return await connection.QueryAsync<OrderDto>(selector.RawSql);
        }

        public async Task<OrderDetailsDto> GetByIdAsync(int id)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from orders o /**innerjoin**/ /**where**/");

            builder.Select("o.Id as OrderId, o.OrderDate as OrderDate, o.Address_Street as AddressStreet, o.Address_City as AddressCity, " +
                "o.Address_Country as AddressCountry, os.Id as OrderStatusId, os.Name as OrderStatusName, b.Id as BuyerId, b.FirstName as BuyerFirstName, " +
                "b.LastName as BuyerLastName, b.PhoneNumber as BuyerPhoneNumber, b.Email as BuyerEmail, c.Id as ContractorId, c.Name as ContractorName, " +
                "c.Address as ContractorAddress, c.PhoneNumber as ContractorPhoneNumber, c.Email as ContractorEmail, c.City as ContractorCity, " +
                "c.Country as ContractorCountry, oi.Id as OrderItemId, oi.Name as Name, oi.Units as Units, oi.UnitPrice as UnitPrice");

            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.InnerJoin("OrderStatuses os on o.OrderStatusId = os.Id");
            builder.InnerJoin("OrderItems oi on o.OrderId = oi.OrderId");
            builder.Where("o.Id = @id", new { id });

            using var connection = _dapperContext.CreateConnection();
            connection.Open();

            var sqlQueryResult = await connection.QueryAsync<OrderDetailsDto, OrderItemDto, OrderDetailsDto>(selector.RawSql,
                map: (orderDetails, orderItem) =>
                {
                    orderDetails.OrderItems.Add(orderItem);
                    return orderDetails;
                },
                splitOn: "OrderItemId");

            return sqlQueryResult.FirstOrDefault();
        }
    }
}
