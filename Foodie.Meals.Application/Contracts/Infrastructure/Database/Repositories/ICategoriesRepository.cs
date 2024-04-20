using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Common.Collections;
using Foodie.Meals.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories
{
    public interface ICategoriesRepository : IGenericRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetAllAsync(IReadOnlyCollection<int> categoryIds);
        Task<PagedList<Category>> GetAllAsync(int pageNumber, int pageSize, string name);
    }
}
