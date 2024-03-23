using Foodie.Common.Application.Requests.Abstractions;
using MediatR;

namespace Foodie.Orders.Application.Functions.Orders.Commands.SetDeliveredOrderStatus
{
    public class SetDeliveredOrderStatusCommand : ILocationRequest, IRequest
    {
        public int Id { get; set; }
        public int LocationId { get; set; }

        public SetDeliveredOrderStatusCommand(int id)
        {
            Id = id;
        }
    }
}
