using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocations
{
    public class LocationResponse
    {
        public int LocationId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
        public string RestaurantName { get; set; }
    }
}
