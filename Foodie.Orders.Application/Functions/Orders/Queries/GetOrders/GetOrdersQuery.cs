using Foodie.Shared.Queries;
using MediatR;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Foodie.Orders.Application.Functions.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : PagedQuery, IRequest<GetOrdersQueryResponse>
    {
        public string BuyerEmail { get; set; }
        public string OrderStatusName { get; set; }
        public string ContractorName { get; set; } // TODO: Change to contractor id
        public int? LocationId { get; set; }
    }
}
