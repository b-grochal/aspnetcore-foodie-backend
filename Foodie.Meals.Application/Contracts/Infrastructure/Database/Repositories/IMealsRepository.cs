using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Common.Collections;
using Foodie.Meals.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Database.Repositories
{
    public interface IMealsRepository : IGenericRepository<Meal>
    {
        Task<IReadOnlyList<Meal>> GetAllAsync(int restaurantId);
        Task<PagedList<Meal>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, string name);
    }
}
