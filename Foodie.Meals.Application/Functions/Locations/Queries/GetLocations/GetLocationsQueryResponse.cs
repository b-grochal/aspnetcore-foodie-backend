using Foodie.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocations
{
    public class GetLocationsQueryResponse : PagedResponse
    {
        public IEnumerable<LocationDto> Locations{ get; set; }
        public int? RestaurantId { get; set; }
        public int? CityId { get; set; }
    }

    public class LocationDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
        public string RestaurantName { get; set; }
    }
}
