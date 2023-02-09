using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrders
{
    public class GetOrdersQueryResponse : PagedResponse
    {
        public IEnumerable<OrderDto> Orders { get; set; }
        public string BuyerEmail { get; set; }
        public string OrderStatusName { get; set; }
        public string ContractorName { get; set; }
        public int? LocationId { get; set; }
    }
}
