using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Meals.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface IMealsRepository : IRepository<Meal>
    {
        Task<IReadOnlyList<Meal>> GetAllAsync(int restaurantId);
        Task<IEnumerable<Meal>> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, string name);
    }
}
