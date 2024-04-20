using Foodie.Common.Collections;
using Foodie.Common.Linq;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Meals.Infrastructure.Database;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Database.Repositories
{
    public class CountriesRepository : BaseMealsRepository<Country>, ICountriesRepository
    {
        public CountriesRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<PagedList<Country>> GetAllAsync(int pageNumber, int pageSize, string name)
        {
            return _dbContext.Countries
                .Where(c => name == null || c.Name.Equals(name))
                .Paginate(pageNumber, pageSize);
        }
    }
}
