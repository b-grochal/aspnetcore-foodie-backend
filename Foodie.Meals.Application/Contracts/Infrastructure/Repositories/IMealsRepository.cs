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
    public interface IMealsRepository : IAsyncRepository<Meal>
    {
        Task<IReadOnlyList<Meal>> GetAllAsync(int restaurantId);
        PagedList<Meal> GetAllAsync(int pageNumber, int pageSize, int? restaurantId, string name);
    }
}
