using Foodie.Common.Application.Authorization;
using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Functions.Orders.Commands.SetInDeliveryOrderStatus;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class SetInDeliveryOrderStatusCommandAuthorizer : RequestAuthorizer<SetInDeliveryOrderStatusCommand>
    {
        public override void BuildPolicy(SetInDeliveryOrderStatusCommand request)
        {
            UseRequirement(new SameLocationLikeOrderRequirement
            {
                LocationId = request.LocationId,
                OrderId = request.Id
            });
        }
    }
}
