using Foodie.Common.Application.Requests.Abstractions;
using MediatR;

namespace Foodie.Orders.Application.Functions.Orders.Commands.SetInDeliveryOrderStatus
{
    public class SetInDeliveryOrderStatusCommand : ILocationRequest, IRequest
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public SetInDeliveryOrderStatusCommand(int id)
        {
            Id = id;
        }
    }
}
