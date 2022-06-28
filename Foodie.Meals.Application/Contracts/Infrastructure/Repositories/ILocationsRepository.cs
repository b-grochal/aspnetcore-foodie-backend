using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using Foodie.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ILocationsRepository : IAsyncRepository<Location>
    {
        Task<PagedList<Location>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, int? cityId);
        Task<IReadOnlyList<Location>> GetAllAsync(int restaurantId, int? cityId);
        Task<Location> GetByIdWithRelatedDataAsync(int id);
    }
}
