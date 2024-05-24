using Foodie.Common.Application.Requests.Queries.Interfaces;
using Foodie.Common.Results;
using MediatR;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocations
{
    public class GetLocationsQuery : PagedQuery, IRequest<Result<GetLocationsQueryResponse>>
    {
        public int? RestaurantId { get; set; }
        public int? CityId { get; set; }
    }
}
