using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : PagedQuery, IRequest<GetOrdersQueryResponse>
    {
        public string BuyerEmail { get; set; }
        public string OrderStatusName { get; set; }
        public string ContractorName { get; set; }
    }
}
