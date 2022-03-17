using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ILocationsRepository
    {
        Task CreateLocation(Location location);
        Task DeleteLocation(int locationId);
        Task UpdateLocation(Location location);
        Task<City> GetLocation(int locationId);
        Task<IEnumerable<Location>> GetLocations();
        Task<PagedList<Location>> GetLocations(int pageNumber, int pageSize, int restaurantId, int cityId);

    }
}
