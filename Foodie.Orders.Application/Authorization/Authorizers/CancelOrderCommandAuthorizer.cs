using Foodie.Common.Application.Authorization;
using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Functions.Orders.Commands.CancelOrder;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class CancelOrderCommandAuthorizer : RequestAuthorizer<CancelOrderCommand>
    {
        public override void BuildPolicy(CancelOrderCommand request)
        {
            UseRequirement(new SameLocationLikeOrderRequirement
            {
                LocationId = request.LocationId,
                OrderId = request.Id
            });
        }
    }
}
