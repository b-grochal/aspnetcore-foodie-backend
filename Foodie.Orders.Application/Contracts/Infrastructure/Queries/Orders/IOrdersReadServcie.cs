using Foodie.Common.Collections;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Queries.Orders
{
    public interface IOrdersReadServcie
    {
        Task<PagedList<OrderQueryDto>> GetAllAsync(int pageNumber, int pageSize, int customerId, int? orderStatusId, string contractorName);
    }
}
