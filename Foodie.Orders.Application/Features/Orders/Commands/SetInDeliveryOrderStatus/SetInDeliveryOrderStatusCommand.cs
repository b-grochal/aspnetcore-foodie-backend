using Foodie.Common.Application.Requests.Interfaces;
using Foodie.Common.Application.Requests.Commands.Interfaces;
using Foodie.Common.Results;
using MediatR;
using Foodie.Common.Enums;

namespace Foodie.Orders.Application.Features.Orders.Commands.SetInDeliveryOrderStatus
{
    public class SetInDeliveryOrderStatusCommand : IApplicationUserLocationRequest, IAuditableCommand, IRequest<Result>
    {
        public int Id { get; set; }

        public int LocationId { get; set; }

        public int ApplicationUserId { get; set; }

        public string ApplicationUserEmail { get; set; }

        public ApplicationUserRole Role { get; set; }

        public SetInDeliveryOrderStatusCommand(int id)
        {
            Id = id;
        }
    }
}
