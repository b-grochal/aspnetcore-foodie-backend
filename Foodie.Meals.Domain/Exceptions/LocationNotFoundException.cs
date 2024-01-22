using Foodie.Common.Exceptions;

namespace Foodie.Meals.Domain.Exceptions
{
    public sealed class LocationNotFoundException : NotFoundException
    {
        public LocationNotFoundException(int locationId) : base($"The location with the indetifier {locationId} was not found.") { }
    }
}
