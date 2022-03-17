using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocations
{
    public class LocationsListResponse : PagedResponse
    {
        public IEnumerable<LocationResponse> Locations{ get; set; }
        public int RestaurantId { get; set; }
        public int CityId { get; set; }
    }
}
