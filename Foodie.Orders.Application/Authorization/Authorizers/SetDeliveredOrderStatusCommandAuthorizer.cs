using Foodie.Common.Application.Authorization;
using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Features.Orders.Commands.SetDeliveredOrderStatus;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class SetDeliveredOrderStatusCommandAuthorizer : RequestAuthorizer<SetDeliveredOrderStatusCommand>
    {
        public override void BuildPolicy(SetDeliveredOrderStatusCommand request)
        {
            UseRequirement(new SameLocationLikeOrderRequirement
            {
                LocationId = request.LocationId,
                OrderId = request.Id,
                Role = request.Role
            });
        }
    }
}
