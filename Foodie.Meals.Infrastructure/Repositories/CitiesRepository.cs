using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Types.Pagination;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class CitiesRepository : BaseMealsRepository<City>, ICitiesRepository
    {
        public CitiesRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<PagedResult<City>> GetAllAsync(int pageNumber, int pageSize, string name, int? countryId)
        {
            return dbContext.Cities
                .Where(c => name == null || c.Name.Equals(name))
                .Where(c => countryId == null || c.CountryId == countryId)
                .Paginate(pageNumber, pageSize);
        }
    }
}
