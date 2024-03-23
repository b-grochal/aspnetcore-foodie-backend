using Foodie.Common.Application.Requests.Abstractions;
using MediatR;

namespace Foodie.Orders.Application.Functions.Orders.Commands.CancelOrder
{
    public class CancelOrderCommand : ILocationRequest, IRequest
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public CancelOrderCommand(int id)
        {
            Id = id;
        }
    }
}
