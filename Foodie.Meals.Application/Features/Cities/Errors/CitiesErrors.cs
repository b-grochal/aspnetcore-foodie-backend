using Foodie.Common.Results;

namespace Foodie.Meals.Application.Features.Cities.Errors
{
    public static class CitiesErrors
    {
        public static Error CityNotFoundById(int id) =>
            Error.NotFound("City.CityNotFoundById",
                $"The city with the identifier {id} was not found.");
    }
}
