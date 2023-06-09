using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders
{
    public interface IOrdersQueries
    {
        Task<OrderDetailsQueryDto> GetByIdAsync(int id);
        Task<OrderDetailsQueryDto> GetByIdAsync(int id, int customerId);
        Task<PagedList<OrderQueryDto>> GetAllAsync(int pageNumber, int pageSize, string buyerEmail, string orderStatusName, string contractorName, int? locationId);
        Task<PagedList<OrderQueryDto>> GetAllAsync(int pageNumber, int pageSize, int customerId, int? orderStatusId, string contractorName);
    }
}
