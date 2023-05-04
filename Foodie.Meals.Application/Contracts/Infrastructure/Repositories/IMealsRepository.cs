using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Repositories;
using Foodie.Shared.Types.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface IMealsRepository : IAsyncRepository<Meal>
    {
        Task<IReadOnlyList<Meal>> GetAllAsync(int restaurantId);
        Task<PagedResult<Meal>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, string name);
    }
}
