using Foodie.Common.Collections;
using Foodie.Common.Linq;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Database.Repositories
{
    public class RestaurantsRepository : BaseMealsRepository<Restaurant>, IRestaurantsRepository
    {
        public RestaurantsRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<PagedList<Restaurant>> GetAllAsync(int pageNumber, int pageSize, int? categoryId, string name, string cityName)
        {
            return _dbContext.Restaurants
                .Where(r => categoryId == null || r.Categories.Any(c => c.Id == categoryId))
                .Where(r => name == null || r.Name.Equals(name))
                .Where(r => cityName == null || r.Locations.Any(l => l.City.Name.Equals(cityName)))
                .Paginate(pageNumber, pageSize);
        }
    }
}
