using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Functions.Orders.Commands.SetDeliveredOrderStatus;
using Foodie.Shared.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class SetDeliveredOrderStatusCommandAuthorizer : AbstractRequestAuthorizer<SetDeliveredOrderStatusCommand>
    {
        public override void BuildPolicy(SetDeliveredOrderStatusCommand request)
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
