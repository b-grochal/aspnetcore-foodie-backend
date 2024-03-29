﻿using System.Collections.Generic;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurantLocations
{
    public class GetRestaurantLocationsQueryResponse
    {
        public IEnumerable<RestaurantLocationDto> RestaurantLocations { get; set; }
    }

    public class RestaurantLocationDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CityName { get; set; }
    }
}
