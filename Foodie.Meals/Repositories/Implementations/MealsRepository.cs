using Foodie.Meals.Context;
using Foodie.Meals.Models;
using Foodie.Meals.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Repositories.Implementations
{
    public class MealsRepository : IMealsRepository
    {
        private readonly MealsDbContext mealsDbContext;

        public MealsRepository(MealsDbContext mealsDbContext)
        {
            this.mealsDbContext = mealsDbContext;
        }

        public async Task CreateMeal(Meal meal)
        {
            await mealsDbContext.Meals.AddAsync(meal);
            await mealsDbContext.SaveChangesAsync();
        }

        public async Task DeleteMeal(int mealId)
        {
            var meal = await mealsDbContext.Meals.FindAsync(mealId);

            if (meal == null)
            {

            }

            mealsDbContext.Meals.Remove(meal);
            await mealsDbContext.SaveChangesAsync();
        }

        public async Task EditMeal(Meal meal)
        {
            mealsDbContext.Meals.Update(meal);
            await mealsDbContext.SaveChangesAsync();
        }

        public async Task<Meal> GetMeal(int mealId)
        {
            return await mealsDbContext.Meals.FindAsync(mealId);
        }

        public async Task<IEnumerable<Meal>> GetMeals()
        {
            return await mealsDbContext.Meals.ToListAsync();
        }
    }
}
