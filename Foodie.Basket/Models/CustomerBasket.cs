using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Models
{
    public class CustomerBasket
    {
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public CustomerBasket()
        {
                
        }

        public CustomerBasket(string userId)
        {
            this.UserId = userId;
        }
    }
}
