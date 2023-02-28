using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Functions.Orders.Commands.SetInDeliveryOrderStatus;
using Foodie.Shared.Authorization;
using System;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class SetInDeliveryOrderStatusCommandAuthorizer : AbstractRequestAuthorizer<SetInDeliveryOrderStatusCommand>
    {
        public override void BuildPolicy(SetInDeliveryOrderStatusCommand request)
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
