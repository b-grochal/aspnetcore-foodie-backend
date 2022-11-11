using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class LocationsRepository : BaseMealsRepository<Location>, ILocationsRepository
    {
        public LocationsRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<PagedList<Location>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, int? cityId)
        {
            var locations = dbContext.Locations
                .Where(l => restaurantId == null || l.RestaurantId == restaurantId)
                .Where(l => cityId == null || l.CityId == cityId);

            return PagedList<Location>.ToPagedList(locations, pageNumber, pageSize);
        }

        public async Task<IReadOnlyList<Location>> GetAllAsync(int restaurantId, int? cityId)
        {
            var locations = dbContext.Locations
                .Where(l => l.RestaurantId == restaurantId)
                .Where(l => cityId == null || l.CityId == cityId);

            return await locations.ToListAsync();
        }

        public async Task<Location> GetByIdWithRelatedDataAsync(int id)
        {
            return await dbContext.Locations
                .Include(l => l.City)
                .Include(l => l.Restaurant)
                .FirstOrDefaultAsync(l => l.LocationId == id);
        }
    }
}
