using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Repositories;
using Foodie.Shared.Types.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ICategoriesRepository : IAsyncRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetAllAsync(IReadOnlyCollection<int> categoryIds);
        Task<PagedResult<Category>> GetAllAsync(int pageNumber, int pageSize, string name);
    }
}
