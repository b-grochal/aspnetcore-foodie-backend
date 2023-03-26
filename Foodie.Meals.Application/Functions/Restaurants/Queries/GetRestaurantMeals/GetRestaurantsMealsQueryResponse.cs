using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantMeals
{
    public class GetRestaurantsMealsQueryResponse
    {
        public IEnumerable<RestaurantMealDto> RestaurantMeals { get; set; }
    }

    public class RestaurantMealDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
