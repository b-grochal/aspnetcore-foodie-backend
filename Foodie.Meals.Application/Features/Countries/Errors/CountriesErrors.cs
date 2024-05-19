using Foodie.Common.Results;

namespace Foodie.Meals.Application.Features.Countries.Errors
{
    public static class CountriesErrors
    {
        public static Error CountryNotFoundById(int id) =>
            Error.NotFound("Countries.CountryNotFoundById",
                $"The country with the identifier {id} was not found.");
    }
}
