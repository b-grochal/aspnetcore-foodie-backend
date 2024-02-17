using Foodie.Common.Domain.ValueObjects;
using System.Collections.Generic;

namespace Foodie.Orders.Domain.Orders.ValueObjects
{
    public class DeliveryAddress : ValueObject
    {
        public string Street { get; }
        public string City { get; }
        public string Country { get; }

        private DeliveryAddress() { }

        private DeliveryAddress(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }

        public static DeliveryAddress Create(string street, string city, string country)
        {
            return new DeliveryAddress(street, city, country);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return Country;
        }
    }
}
