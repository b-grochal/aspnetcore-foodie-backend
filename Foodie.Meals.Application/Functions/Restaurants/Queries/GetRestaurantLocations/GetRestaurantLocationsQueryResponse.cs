using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations
{
    public class GetRestaurantLocationsQueryResponse
    {
        public IEnumerable<RestaurantLocationDto> RestaurantLocations { get; set; }
    }
}
