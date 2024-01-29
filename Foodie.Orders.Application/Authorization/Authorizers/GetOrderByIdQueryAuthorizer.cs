using Foodie.Common.Application.Authorization;
using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Functions.Orders.Queries.GetOrderById;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class GetOrderByIdQueryAuthorizer : RequestAuthorizer<GetOrderByIdQuery>
    {
        public override void BuildPolicy(GetOrderByIdQuery request)
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
