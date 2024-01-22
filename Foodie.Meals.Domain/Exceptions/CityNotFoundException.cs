using Foodie.Common.Exceptions;

namespace Foodie.Meals.Domain.Exceptions
{
    public sealed class CityNotFoundException : NotFoundException
    {
        public CityNotFoundException(int cityId) : base($"The city with the indetifier {cityId} was not found.") { }
    }
}
