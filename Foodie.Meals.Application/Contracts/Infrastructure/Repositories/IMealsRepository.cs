using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface IMealsRepository
    {
        Task CreateMeal(Meal meal);
        Task DeleteMeal(int mealId);
        Task UpdateMeal(Meal meal);
        Task<Meal> GetMeal(int mealId);
        Task<IEnumerable<Meal>> GetMeals();
        Task<IEnumerable<Meal>> GetMeals(int restaurantId);
        Task<PagedList<Meal>> GetMeals(int pageNumber, int pageSize, int restaurantId, string name);
    }
}
