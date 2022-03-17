using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ICategoriesRepository
    {
        Task CreateCategory(Category category);
        Task DeleteCategory(int categoryId);
        Task UpdateCategory(Category category);
        Task<Category> GetCategory(int categoryId);
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Category>> GetCategories(IReadOnlyCollection<int> categoryIds);
        Task<PagedList<Category>> GetCategories(int pageNumber, int pageSize, string name);
    }
}
