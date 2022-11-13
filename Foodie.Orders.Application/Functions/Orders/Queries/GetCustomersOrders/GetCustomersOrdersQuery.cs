using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetCustomersOrders
{
    public class GetCustomersOrdersQuery : PagedQuery, IRequest<GetCustomersOrdersQueryResponse>
    {
        public string UserId { get; set; }
        public int? OrderStatusId { get; set; }
        public string ContractorName { get; set; }
    }
}
