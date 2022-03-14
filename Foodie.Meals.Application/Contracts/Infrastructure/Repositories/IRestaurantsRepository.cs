using Foodie.Meals.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Contracts.Infrastructure.Repositories
{
    public interface IRestaurantsRepository
    {
        Task CreateRestaurant(Restaurant restaurant);
        Task DeleteRestaurant(int restaurantId);
        Task UpdateRestaurant(Restaurant restaurant);
        Task<Restaurant> GetRestaurant(int restaurantId);
        Task<IEnumerable<Restaurant>> GetRestaurants();
    }
}
