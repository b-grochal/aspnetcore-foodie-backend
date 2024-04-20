using Foodie.Common.Collections;
using Foodie.Common.Linq;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Meals.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Database.Repositories
{
    public class LocationsRepository : BaseMealsRepository<Location>, ILocationsRepository
    {
        public LocationsRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<PagedList<Location>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, int? cityId)
        {
            return _dbContext.Locations
                .Where(l => restaurantId == null || l.RestaurantId == restaurantId)
                .Where(l => cityId == null || l.CityId == cityId)
                .Paginate(pageNumber, pageSize);
        }

        public async Task<IReadOnlyList<Location>> GetAllAsync(int restaurantId, int? cityId)
        {
            var locations = _dbContext.Locations
                .Where(l => l.RestaurantId == restaurantId)
                .Where(l => cityId == null || l.CityId == cityId);

            return await locations.ToListAsync();
        }

        public async Task<Location> GetByIdWithRelatedDataAsync(int id)
        {
            return await _dbContext.Locations
                .Include(l => l.City)
                .Include(l => l.Restaurant)
                .FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
