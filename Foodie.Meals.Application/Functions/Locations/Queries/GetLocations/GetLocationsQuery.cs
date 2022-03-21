using Foodie.Shared.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocations
{
    public class GetLocationsQuery : PagedQuery, IRequest<LocationsListResponse>
    {
        public int? RestaurantId { get; set; }
        public int? CityId { get; set; }
    }
}
