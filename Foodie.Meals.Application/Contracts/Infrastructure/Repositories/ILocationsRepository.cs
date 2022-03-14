using Foodie.Meals.Domain.Entities;
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
        Task UpdateLocation(City editedLocation);
    }
}
