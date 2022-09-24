using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrderById
{
    public class OrderItemDto
    {
        public int OrderItemId { get; set; }
        public string Name { get; set; }
        public int Units { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
