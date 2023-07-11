using Foodie.Shared.Responses;
using System.Collections.Generic;

namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCities
{
    public class GetCitiesQueryResponse : PagedResponse
    {
        public IEnumerable<CityDto> Cities { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }

    public class CityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
    }
}
