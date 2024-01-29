using Foodie.Common.Application.Authorization;
using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Functions.Orders.Commands.SetDeliveredOrderStatus;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class SetDeliveredOrderStatusCommandAuthorizer : RequestAuthorizer<SetDeliveredOrderStatusCommand>
    {
        public override void BuildPolicy(SetDeliveredOrderStatusCommand request)
        {
            if (request.LocationId.HasValue)
                UseRequirement(new SameLocationLikeOrderRequirement
                {
                    LocationId = request.LocationId.Value,
                    OrderId = request.Id
                });
        }
    }
}
