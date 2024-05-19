using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Application.Requests.Queries.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Orders.Queries.GetOrders
{
    public class GetOrdersQuery : PagedQuery, IApplicationUserLocationRequest, IRequest<Result<GetOrdersQueryResponse>>
    {
        public string BuyerEmail { get; set; }
        public string OrderStatusName { get; set; } // TODO: Change to order status id
        public string ContractorName { get; set; } // TODO: Change to contractor id
        public int LocationId { get; set; }
    }
}
