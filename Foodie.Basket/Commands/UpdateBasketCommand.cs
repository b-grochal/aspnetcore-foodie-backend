using Foodie.Basket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Basket.Commands
{
    public class UpdateBasketCommand
    {
        public string UserId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
