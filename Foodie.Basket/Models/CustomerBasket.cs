using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Models
{
    public class CustomerBasket
    {
        public int LocationId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
