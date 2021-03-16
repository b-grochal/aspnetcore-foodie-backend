using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Meals.Responses.Meals
{
    public class MealResponse
    {
        public int MealId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int RestaurantId { get; set; }
        public string RestautantName { get; set; }
    }
}
