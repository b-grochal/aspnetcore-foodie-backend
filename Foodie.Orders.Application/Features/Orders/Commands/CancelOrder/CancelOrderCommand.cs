using Foodie.Common.Application.Requests.Abstractions;
using Foodie.Common.Application.Requests.Commands.Abstractions;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Orders.Application.Features.Orders.Commands.CancelOrder
{
    public class CancelOrderCommand : IApplicationUserLocationRequest, IAuditableCommand, IRequest<Result>
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public string User { get; set; }

        public CancelOrderCommand(int id)
        {
            Id = id;
        }
    }
}
