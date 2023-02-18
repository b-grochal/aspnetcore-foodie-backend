using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Functions.Orders.Commands.CancelOrder;
using Foodie.Shared.Authorization;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class CancelOrderCommandAuthorizer : AbstractRequestAuthorizer<CancelOrderCommand>
    {
        public override void BuildPolicy(CancelOrderCommand request)
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
