using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Common.Collections;
using Foodie.Meals.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ILocationsRepository : IRepository<Location>
    {
        Task<PagedList<Location>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, int? cityId);
        Task<IReadOnlyList<Location>> GetAllAsync(int restaurantId, int? cityId);
        Task<Location> GetByIdWithRelatedDataAsync(int id);
    }
}
