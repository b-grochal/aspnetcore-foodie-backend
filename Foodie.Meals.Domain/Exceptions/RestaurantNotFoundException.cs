using Foodie.Common.Exceptions;

namespace Foodie.Meals.Domain.Exceptions
{
    public sealed class RestaurantNotFoundException : NotFoundException
    {
        public RestaurantNotFoundException(int restaurantId) : base($"The restaurant with the indetifier {restaurantId} was not found.") { }
    }
}
