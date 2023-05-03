using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ICategoriesRepository : IAsyncRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetAllAsync(IReadOnlyCollection<int> categoryIds);
        Task<IEnumerable<Category>> GetAllAsync(int pageNumber, int pageSize, string name);
    }
}
