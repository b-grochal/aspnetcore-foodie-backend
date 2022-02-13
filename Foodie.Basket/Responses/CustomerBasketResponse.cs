using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Responses
{
    public class CustomerBasketResponse
    {
        public string UserId { get; set; }
        public List<BasketItemResponse> Items { get; set; }
    }
}
