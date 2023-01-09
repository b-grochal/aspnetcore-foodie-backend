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
}
