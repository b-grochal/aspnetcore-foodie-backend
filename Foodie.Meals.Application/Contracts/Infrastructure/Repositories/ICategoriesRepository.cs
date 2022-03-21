using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using Foodie.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface ICategoriesRepository : IAsyncRepository<Category>
    {
        Task<IReadOnlyList<Category>> GetAllAsync(IReadOnlyCollection<int> categoryIds);
        Task<PagedList<Category>> GetAllAsync(int pageNumber, int pageSize, string name);
    }
}
