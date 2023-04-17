using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Model
{
    public class CustomerBasket
    {
        public int LocationId { get; set; }
        public List<CustomerBasketItem> Items { get; set; }
    }
}
