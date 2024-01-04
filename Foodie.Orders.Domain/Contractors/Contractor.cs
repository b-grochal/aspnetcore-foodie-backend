using Foodie.Common.Domain.AggregateRoots;
using System;

namespace Foodie.Orders.Domain.Contractors
{
    public class Contractor : AggregateRoot
    {
        public int RestaurantId { get; private set; }
        public string Name { get; private set; }
        public int LocationId { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public int CityId { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public Contractor(int restaurantId, string name, int locationId, string address, string phoneNumber, string email, int cityId, string city, string country)
        {
            RestaurantId = restaurantId > 0 ? restaurantId : throw new ArgumentNullException(nameof(restaurantId));
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            LocationId = locationId > 0 ? locationId : throw new ArgumentNullException(nameof(locationId));
            Address = !string.IsNullOrWhiteSpace(address) ? address : throw new ArgumentNullException(nameof(address));
            PhoneNumber = !string.IsNullOrWhiteSpace(phoneNumber) ? phoneNumber : throw new ArgumentNullException(nameof(phoneNumber));
            Email = !string.IsNullOrWhiteSpace(email) ? email : throw new ArgumentNullException(nameof(email));
            CityId = cityId > 0 ? cityId : throw new ArgumentNullException(nameof(cityId));
            City = !string.IsNullOrWhiteSpace(city) ? city : throw new ArgumentNullException(nameof(city));
            Country = !string.IsNullOrWhiteSpace(country) ? country : throw new ArgumentNullException(nameof(country));
        }
    }
}
