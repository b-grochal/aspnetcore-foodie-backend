using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Orders.Commands.SetDeliveredOrderStatus
{
    public class SetDeliveredOrderStatusCommand : IApplicationUserLocationRequest, IRequest<Result>
    {
        public int Id { get; set; }
        public int LocationId { get; set; }

        public SetDeliveredOrderStatusCommand(int id)
        {
            Id = id;
        }
    }
}
