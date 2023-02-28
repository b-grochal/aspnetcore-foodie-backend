using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Functions.Orders.Commands.SetInProgressOrderStatus;
using Foodie.Shared.Authorization;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class SetInProgressOrderStatusCommandAuthorizer : AbstractRequestAuthorizer<SetInProgressOrderStatusCommand>
    {
        public override void BuildPolicy(SetInProgressOrderStatusCommand request)
        {
            if (request.LocationId.HasValue)
                UseRequirement(new SameLocationLikeOrderRequirement
                {
                    LocationId = request.LocationId.Value,
                    OrderId = request.OrderId
                });
        }
    }
}
