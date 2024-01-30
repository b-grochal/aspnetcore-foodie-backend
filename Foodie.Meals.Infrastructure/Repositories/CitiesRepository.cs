using Foodie.Common.Collections;
using Foodie.Common.Extensions;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class CitiesRepository : BaseMealsRepository<City>, ICitiesRepository
    {
        public CitiesRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<PagedList<City>> GetAllAsync(int pageNumber, int pageSize, string name, int? countryId)
        {
            return dbContext.Cities
                .Where(c => name == null || c.Name.Equals(name))
                .Where(c => countryId == null || c.CountryId == countryId)
                .Paginate(pageNumber, pageSize);
        }
    }
}
