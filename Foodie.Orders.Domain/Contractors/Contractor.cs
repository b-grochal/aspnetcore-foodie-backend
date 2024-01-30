using Foodie.Common.Domain.AggregateRoots;
using System;

namespace Foodie.Orders.Domain.Contractors
{
    public class Contractor : AggregateRoot
    {
        public int RestaurantId { get; }
        public string Name { get; }
        public int LocationId { get; }
        public string Address { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public int CityId { get; }
        public string City { get; }
        public int CountryId { get; }
        public string Country { get; }

        private Contractor(int restaurantId, string name, int locationId, string address, string phoneNumber, string email, int cityId, string city, int countryId, string country)
        {
            RestaurantId = restaurantId > 0 ? restaurantId : throw new ArgumentNullException(nameof(restaurantId));
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            LocationId = locationId > 0 ? locationId : throw new ArgumentNullException(nameof(locationId));
            Address = !string.IsNullOrWhiteSpace(address) ? address : throw new ArgumentNullException(nameof(address));
            PhoneNumber = !string.IsNullOrWhiteSpace(phoneNumber) ? phoneNumber : throw new ArgumentNullException(nameof(phoneNumber));
            Email = !string.IsNullOrWhiteSpace(email) ? email : throw new ArgumentNullException(nameof(email));
            CityId = cityId > 0 ? cityId : throw new ArgumentNullException(nameof(cityId));
            City = !string.IsNullOrWhiteSpace(city) ? city : throw new ArgumentNullException(nameof(city));
            CountryId = countryId > 0 ? countryId : throw new ArgumentNullException(nameof(countryId));
            Country = !string.IsNullOrWhiteSpace(country) ? country : throw new ArgumentNullException(nameof(country));
        }

        public static Contractor Create(int restaurantId, string name, int locationId, string address, string phoneNumber, string email, int cityId, string city, int countryId, string country)
        {
            return new Contractor(restaurantId, name, locationId, address, phoneNumber, email, cityId, city, countryId, country);
        }
    }
}
