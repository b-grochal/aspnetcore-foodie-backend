using Foodie.Common.Results;

namespace Foodie.Meals.Application.Features.Locations.Errors
{
    public static class LocationsErrors
    {
        public static Error LocationNotFoundById(int id) =>
            Error.NotFound("Locations.LocationNotFoundById",
                $"The locations with the identifier {id} was not found.");
    }
}
