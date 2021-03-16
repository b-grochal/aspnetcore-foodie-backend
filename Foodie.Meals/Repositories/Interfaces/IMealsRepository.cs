using Foodie.Meals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Repositories.Interfaces
{
    public interface IMealsRepository
    {
        Task CreateMeal(Meal meal);
        Task DeleteMeal(int mealId);
        Task EditMeal(Meal meal);
        Task<Meal> GetMeal(int mealId);
        Task<IEnumerable<Meal>> GetMeals();
    }
}
