using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrders
{
    public class GetCustomersOrdersQueryResponse : PagedResponse
    {
        public IEnumerable<CustomersOrderDto> CustomersOrders { get; set; }
        public int? OrderStatusId { get; set; }
        public string ContractorName { get; set; }
    }
}
