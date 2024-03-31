using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Orders.Commands.SetInDeliveryOrderStatus
{
    public class SetInDeliveryOrderStatusCommand : IApplicationUserLocationRequest, IRequest<Result>
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public SetInDeliveryOrderStatusCommand(int id)
        {
            Id = id;
        }
    }
}
