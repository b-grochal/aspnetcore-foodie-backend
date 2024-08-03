using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Application.Requests.Queries.Interfaces;
using Foodie.Common.Enums;
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

        public ApplicationUserRole Role { get; set; }
    }
}
