using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Models
{
    public class Basket
    {
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; } = new List<BasketItem>();

        public Basket()
        {
                
        }

        public Basket(string userId)
        {
            this.UserId = userId;
        }
    }
}
