using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using Foodie.Shared.Types.Pagination;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class RestaurantsRepository : BaseMealsRepository<Restaurant>, IRestaurantsRepository
    {
        public RestaurantsRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResult<Restaurant>> GetAllAsync(int pageNumber, int pageSize, int? categoryId, string name, string cityName)
        {
            return dbContext.Restaurants
                .Where(r => categoryId == null || r.Categories.Any(c => c.Id == categoryId))
                .Where(r => name == null || r.Name.Equals(name))
                .Where(r => cityName == null || r.Locations.Any(l => l.City.Name.Equals(name)))
                .Paginate(pageNumber, pageSize);
        }
    }
}
