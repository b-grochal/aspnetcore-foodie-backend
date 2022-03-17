using Foodie.Meals.Domain.Entities;
using Foodie.Shared.Extensions;
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
        Task<List<Restaurant>> GetRestaurants();
        Task<PagedList<Restaurant>> GetRestaurants(int pageNumber, int pageSize, int categoryId, string name, string cityName);
    }
}
