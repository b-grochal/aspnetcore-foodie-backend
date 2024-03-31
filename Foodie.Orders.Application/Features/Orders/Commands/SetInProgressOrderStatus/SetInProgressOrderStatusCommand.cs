using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Orders.Commands.SetInProgressOrderStatus
{
    public class SetInProgressOrderStatusCommand : IApplicationUserLocationRequest, IRequest<Result>
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public SetInProgressOrderStatusCommand(int id)
        {
            Id = id;
        }
    }
}
