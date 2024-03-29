﻿using Foodie.Common.Application.Authorization;
using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Functions.Orders.Commands.SetInProgressOrderStatus;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class SetInProgressOrderStatusCommandAuthorizer : RequestAuthorizer<SetInProgressOrderStatusCommand>
    {
        public override void BuildPolicy(SetInProgressOrderStatusCommand request)
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
