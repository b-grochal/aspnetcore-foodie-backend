using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Responses
{
    public class BasketItemResponse
    {
        public int BasketItemId { get; set; }
        public int MealId { get; set; }
        public string MealName { get; set; }
        public decimal MealPrice { get; set; }
        public int Quantity { get; set; }
        public string RestaurantName { get; set; }
    }
}
