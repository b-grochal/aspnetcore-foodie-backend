using Foodie.Common.Application.Requests.Abstractions;
using MediatR;

namespace Foodie.Orders.Application.Functions.Orders.Commands.SetInProgressOrderStatus
{
    public class SetInProgressOrderStatusCommand : ILocationRequest, IRequest
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public SetInProgressOrderStatusCommand(int id)
        {
            Id = id;
        }
    }
}
