using Foodie.Common.Domain.ValueObjects;
using System.Collections.Generic;

namespace Foodie.Orders.Domain.Orders.ValueObjects
{
    public class DeliveryAddress : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public DeliveryAddress() { }

        public DeliveryAddress(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return Country;
        }
    }
}
