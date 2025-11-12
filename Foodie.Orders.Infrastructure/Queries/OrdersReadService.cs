using Dapper;
using Foodie.Common.Collections;
using Foodie.Common.Infrastructure.Database.Connections.Interfaces;
using Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlBuilder;

namespace Foodie.Orders.Infrastructure.Queries
{
    public class OrdersReadService : IOrdersReadServcie
    {
        private readonly IDbConnecionFactory _dapperContext;

        public OrdersReadService(IDbConnecionFactory dapperContext)
        {
            _dapperContext = dapperContext;
        }

        // GET MY ORDERS
        public async Task<PagedList<OrderQueryDto>> GetAllAsync(int pageNumber, int pageSize, int customerId, int? orderStatusId, string contractorName)
        {
            var selector = PrepareSqlTemplateForGettingAllOrders(pageNumber, pageSize, customerId, orderStatusId, contractorName);

            using var connection = _dapperContext.CreateConnection();

            connection.Open();

            var orders = await connection.QueryAsync<OrderQueryDto>(selector.RawSql, selector.Parameters);
            return PagedList<OrderQueryDto>.Create(orders, pageNumber, pageSize);
        }

        private Template PrepareSqlTemplateForGettingAllOrders(int pageNumber, int pageSize, int customerId, int? orderStatusId, string contractorName)
        {
            var builder = new SqlBuilder();

            var selector = builder.AddTemplate("Select /**select**/ from orders o /**innerjoin**/ /**where**/ /**orderby**/ offset @offset rows fetch next @pageSize rows only", new { offset = (pageNumber - 1) * pageSize, pageSize });

            builder.Select("o.Id as OrderId, o.OrderStatus as OrderStatus, b.Id as BuyerId, b.Email as BuyerEmail, c.Id as ContractorId, c.Name as ContractorName");
            builder.InnerJoin("Buyers b on o.BuyerId = b.Id");
            builder.InnerJoin("Contractors c on o.ContractorId = c.Id");
            builder.OrderBy("o.Id desc");
            builder.Where("b.CustomerId = @customerId", new { customerId });

            if (orderStatusId != null)
                builder.Where("os.Id = @orderStatusId", new { orderStatusId.Value });

            if (contractorName != null)
                builder.Where("c.Name like @contractorName", new { contractorName = $"%{contractorName}%" });

            return selector;
        }
    }
}
