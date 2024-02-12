using Foodie.Common.Collections;
using Foodie.Common.Linq;
using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class CountriesRepository : BaseMealsRepository<Country>, ICountriesRepository
    {
        public CountriesRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<PagedList<Country>> GetAllAsync(int pageNumber, int pageSize, string name)
        {
            return dbContext.Countries
                .Where(c => name == null || c.Name.Equals(name))
                .Paginate(pageNumber, pageSize);
        }
    }
}
