using System.Collections.Generic;

namespace Foodie.Meals.Infrastructure.Database.Seed
{
    public class CategoryRestaurantsSeed
    {
        public static string JoinTableName = "CategoryRestaurant";

        public static List<dynamic> Get()
        {
            return new List<dynamic>
            {
                new { CategoryId = SeedConsts.BurgerCategory, RestaurantId = SeedConsts.KfcRestaurant, IsDeleted = false },
                new { CategoryId = SeedConsts.PizzaCategory, RestaurantId = SeedConsts.PizzaHutRestaurant, IsDeleted = false },
                new { CategoryId = SeedConsts.BurgerCategory, RestaurantId = SeedConsts.McDonaldsRestaurant, IsDeleted = false }
            };
        }
    }
}
