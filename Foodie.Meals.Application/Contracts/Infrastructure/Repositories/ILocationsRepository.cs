using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Repositories;
using Foodie.Shared.Types.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ILocationsRepository : IRepository<Location>
    {
        Task<PagedResult<Location>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, int? cityId);
        Task<IReadOnlyList<Location>> GetAllAsync(int restaurantId, int? cityId);
        Task<Location> GetByIdWithRelatedDataAsync(int id);
    }
}
