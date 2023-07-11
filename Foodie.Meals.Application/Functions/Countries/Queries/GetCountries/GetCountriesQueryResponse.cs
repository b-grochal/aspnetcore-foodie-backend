using Foodie.Shared.Responses;
using System.Collections.Generic;

namespace Foodie.Meals.Application.Functions.Countries.Queries.GetCountries
{
    public class GetCountriesQueryResponse : PagedResponse
    {
        public IEnumerable<CountryDto> Countries { get; set; }
        public string Name { get; set; }}
    }

    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
