using Foodie.Common.Application.Responses;

namespace Foodie.Meals.Application.Functions.Countries.Queries.GetCountries
{
    public class GetCountriesQueryResponse : PagedResponse<CountryDto>
    {
        public string Name { get; set; }
    }

    public class CountryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

