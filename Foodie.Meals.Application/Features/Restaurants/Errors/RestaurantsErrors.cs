using Foodie.Common.Results;

namespace Foodie.Meals.Application.Features.Restaurants.Errors
{
    public static class RestaurantsErrors
    {
        public static Error RestaurantNotFoundById(int id) =>
            Error.NotFound("Restaurants.RestaurantNotFoundById",
                $"The restaurant with the identifier {id} was not found.");
    }
}
