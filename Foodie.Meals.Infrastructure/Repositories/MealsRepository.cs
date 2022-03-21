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
    public class MealsRepository : BaseMealsRepository<Meal>, IMealsRepository
    {
        public MealsRepository(MealsDbContext dbContext) : base(dbContext) { }

        public Task<IReadOnlyList<Meal>> GetAllAsync(int restaurantId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Meal>> GetAllAsync(int pageNumber, int pageSize, int restaurantId, string name)
        {
            throw new NotImplementedException();
        }
    }
}
