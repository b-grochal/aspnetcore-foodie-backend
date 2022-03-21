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
    public class RestaurantsRepository : BaseMealsRepository<Restaurant>, IRestaurantsRepository
    {
        public RestaurantsRepository(MealsDbContext dbContext) : base(dbContext) { }

        public Task<PagedList<Restaurant>> GetAllAsync(int pageNumber, int pageSize, int categoryId, string name, string cityName)
        {
            throw new NotImplementedException();
        }
    }
}
