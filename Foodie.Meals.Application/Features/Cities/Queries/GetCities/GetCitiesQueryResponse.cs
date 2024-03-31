using Foodie.Common.Application.Responses;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCities
{
    public class GetCitiesQueryResponse : PagedResponse<CityDto>
    {
        public string Name { get; set; }
        public int? CountryId { get; set; }
    }

    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
