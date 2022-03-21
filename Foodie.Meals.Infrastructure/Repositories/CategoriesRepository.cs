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
    public class CategoriesRepository : BaseMealsRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(MealsDbContext dbContext) : base(dbContext) { }

        public Task<IReadOnlyList<Category>> GetAllAsync(IReadOnlyCollection<int> categoryIds)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<Category>> GetAllAsync(int pageNumber, int pageSize, string name)
        {
            throw new NotImplementedException();
        }
    }
}
