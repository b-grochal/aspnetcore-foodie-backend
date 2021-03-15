using Foodie.Meals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Repositories.Interfaces
{
    public interface IRestaurantsRepository
    {
        Task CreateRestaurant(Restaurant restaurant);
        Task DeleteRestaurant(int restaurantId);
        Task EditRestaurant(Restaurant restaurant);
        Task<Restaurant> GetRestaurant(int restaurantId);
        Task<IEnumerable<Restaurant>> GetRestaurants();
    }
}
