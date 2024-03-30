using Foodie.Common.Application.Requests.Queries.Abstractions;
using MediatR;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocations
{
    public class GetLocationsQuery : PagedQuery, IRequest<GetLocationsQueryResponse>
    {
        public int? RestaurantId { get; set; }
        public int? CityId { get; set; }
    }
}
