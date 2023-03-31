using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Infrastructure.DummyData
{
    public class DummyCategoryRestaurants
    {
        public static string JoinTableName = "CategoryRestaurant";

        public static List<dynamic> Get()
        {
            return new List<dynamic>
            {
                new { CategoryId = DummySeed.BurgerCategory, RestaurantId = DummySeed.KfcRestaurant },
                new { CategoryId = DummySeed.PizzaCategory, RestaurantId = DummySeed.PizzaHutRestaurant },
                new { CategoryId = DummySeed.BurgerCategory, RestaurantId = DummySeed.McDonaldsRestaurant }
            };
        }
    }
}
