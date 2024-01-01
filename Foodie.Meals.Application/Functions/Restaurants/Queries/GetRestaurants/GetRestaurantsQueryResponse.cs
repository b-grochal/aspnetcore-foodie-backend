using Foodie.Shared.Responses;
using System.Collections.Generic;

namespace Foodie.Meals.Application.Functions.Restaurants.Queries.GetRestaurants
{
    public class GetRestaurantsQueryResponse : PagedResponse
    {
        public IEnumerable<RestaurantDto> Restaurants { get; set; }
        public int? CategoryId { get; set; }
        public string Name { get; set; }
        public string CityName { get; set; }
    }

    public class RestaurantDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
