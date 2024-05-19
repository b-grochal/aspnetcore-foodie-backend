using Foodie.Common.Collections;
using Foodie.Common.Linq;
using Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories;
using Foodie.Meals.Domain.Entities;
using Foodie.Meals.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.Database.Repositories
{
    public class CategoriesRepository : BaseMealsRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(MealsDbContext dbContext) : base(dbContext) { }

        public async Task<IReadOnlyList<Category>> GetAllAsync(IReadOnlyCollection<int> categoryIds)
        {
            return await _dbContext.Categories
                .Where(c => categoryIds.Contains(c.Id))
                .ToListAsync();
        }

        public async Task<PagedList<Category>> GetAllAsync(int pageNumber, int pageSize, string name)
        {
            return _dbContext.Categories
                .Where(c => name == null || c.Name.Equals(name))
                .Paginate(pageNumber, pageSize);
        }
    }
}
