using Foodie.Common.Collections;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders
{
    public interface IOrdersReadServcie
    {
        Task<OrderDetailsQueryDto> GetByIdAsync(int id);
        Task<OrderDetailsQueryDto> GetMyOrderByIdAsync(int id, int customerId);
        Task<PagedList<OrderQueryDto>> GetAllAsync(int pageNumber, int pageSize, string buyerEmail, string orderStatusName, string contractorName, int? locationId);
        Task<PagedList<OrderQueryDto>> GetAllAsync(int pageNumber, int pageSize, int customerId, int? orderStatusId, string contractorName);
    }
}
