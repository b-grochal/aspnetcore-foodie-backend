using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Repositories;
using Foodie.Shared.Types.Pagination;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface IRestaurantsRepository : IRepository<Restaurant>
    {
        Task<PagedResult<Restaurant>> GetAllAsync(int pageNumber, int pageSize, int? categoryId, string name, string cityName);
    }
}
