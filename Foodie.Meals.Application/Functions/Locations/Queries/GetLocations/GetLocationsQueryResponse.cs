using Foodie.Common.Application.Responses;

namespace Foodie.Meals.Application.Functions.Locations.Queries.GetLocations
{
    public class GetLocationsQueryResponse : PagedResponse<LocationDto>
    {
        public int? RestaurantId { get; set; }
        public int? CityId { get; set; }
    }

    public class LocationDto
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
    }
}
