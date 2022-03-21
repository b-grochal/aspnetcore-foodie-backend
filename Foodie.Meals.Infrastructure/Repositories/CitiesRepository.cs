using Foodie.Meals.Application.Contracts.Infrastructure.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Repositories
{
    public class CitiesRepository : BaseMealsRepository<City>, ICitiesRepository
    {
        public CitiesRepository(MealsDbContext dbContext) : base(dbContext) { }

        public Task<PagedList<City>> GetAllAsync(int pageNumber, int pageSize, string name, string country)
        {
            throw new NotImplementedException();
        }
    }
}
