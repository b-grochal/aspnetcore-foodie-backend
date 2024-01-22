using Foodie.Common.Exceptions;

namespace Foodie.Meals.Domain.Exceptions
{
    public class CountryNotFoundException : NotFoundException
    {
        public CountryNotFoundException(int countryId) : base($"The country with the indetifier {countryId} was not found.") { }
    }
}
