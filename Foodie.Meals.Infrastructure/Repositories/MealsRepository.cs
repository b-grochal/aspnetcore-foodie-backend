using Foodie.Common.Collections;
using Foodie.Common.Linq;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Meals.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class MealsRepository : BaseMealsRepository<Meal>, IMealsRepository
    {
        public MealsRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyList<Meal>> GetAllAsync(int restaurantId)
        {
            return await _dbContext.Meals
                .Where(m => m.RestaurantId == restaurantId)
                .ToListAsync();
        }

        public async Task<PagedList<Meal>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, string name)
        {
            return _dbContext.Meals
                .Where(m => restaurantId == null || m.RestaurantId == restaurantId)
                .Where(m => name == null || m.Name.Equals(name))
                .Paginate(pageNumber, pageSize);
        }
    }
}
