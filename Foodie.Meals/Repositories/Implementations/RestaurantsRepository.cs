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
    public class RestaurantsRepository : IRestaurantsRepository
    {
        private readonly MealsDbContext mealsDbContext;

        public RestaurantsRepository(MealsDbContext mealsDbContext)
        {
            this.mealsDbContext = mealsDbContext;
        }

        public async Task CreateRestaurant(Restaurant restaurant)
        {
            await mealsDbContext.Restaurants.AddAsync(restaurant);
            await mealsDbContext.SaveChangesAsync();
        }

        public async Task DeleteRestaurant(int restaurantId)
        {
            var restaurant = await mealsDbContext.Restaurants.FindAsync(restaurantId);

            if (restaurant == null)
            {

            }

            mealsDbContext.Restaurants.Remove(restaurant);
            await mealsDbContext.SaveChangesAsync();
        }

        public async Task EditRestaurant(Restaurant restaurant)
        {
            mealsDbContext.Restaurants.Update(restaurant);
            await mealsDbContext.SaveChangesAsync();
        }

        public async Task<Restaurant> GetRestaurant(int restaurantId)
        {
            return await mealsDbContext.Restaurants.FindAsync(restaurantId);
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            return await mealsDbContext.Restaurants.ToListAsync();
        }
    }
}
