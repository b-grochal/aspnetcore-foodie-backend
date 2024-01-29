using Foodie.Common.Collections;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Queries.Buyers
{
    public interface IBuyersQueries
    {
        Task<BuyerDetailsQueryDto> GetByIdAsync(int id);
        Task<PagedList<BuyerQueryDto>> GetAllAsync(int pageNumber, int pageSize, string buyerEmail);
    }
}
