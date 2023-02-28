using Foodie.Orders.Application.Authorization.Requirements;
using Foodie.Orders.Application.Functions.Orders.Queries.GetOrderById;
using Foodie.Shared.Authorization;

namespace Foodie.Orders.Application.Authorization.Authorizers
{
    public class GetOrderByIdQueryAuthorizer : AbstractRequestAuthorizer<GetOrderByIdQuery>
    {
        public override void BuildPolicy(GetOrderByIdQuery request)
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
