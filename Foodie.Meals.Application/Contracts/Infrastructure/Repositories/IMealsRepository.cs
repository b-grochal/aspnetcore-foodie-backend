using Foodie.Meals.Domain.Entities;
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
        Task EditMeal(Meal meal);
        Task<Meal> GetMeal(int mealId);
        Task<IEnumerable<Meal>> GetMeals();
    }
}
