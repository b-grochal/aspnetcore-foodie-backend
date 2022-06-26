using Foodie.Orders.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Domain.AggregatesModel.ContractorAggregate
{
    public class Contractor : Entity, IAggregateRoot
    {
        public int RestaurantId { get; private set; }
        public string RestaurantName { get; private set; }
        public int LocationId { get; private set; }
        public string LocationAddress { get; private set; }
        public string LocationPhoneNumber { get; private set; }
        public string LocationEmail { get; private set; }
        public int CityId { get; private set; }
        public string CityName { get; private set; }
        public string Country { get; private set; }

        public Contractor(int restaurantId, string restaurantName, int locationId, string locationAddress, string locationPhoneNumber, string locationEmail, int cityId, string cityName, string country)
        {
            RestaurantId = restaurantId > 0 ? restaurantId : throw new ArgumentNullException(nameof(restaurantId));
            RestaurantName = !string.IsNullOrWhiteSpace(restaurantName) ? restaurantName : throw new ArgumentNullException(nameof(restaurantName));
            LocationId = locationId > 0 ? locationId : throw new ArgumentNullException(nameof(locationId));
            LocationAddress = !string.IsNullOrWhiteSpace(locationAddress) ? locationAddress : throw new ArgumentNullException(nameof(locationAddress));
            LocationPhoneNumber = !string.IsNullOrWhiteSpace(locationPhoneNumber) ? locationPhoneNumber : throw new ArgumentNullException(nameof(locationPhoneNumber));
            LocationEmail = !string.IsNullOrWhiteSpace(locationEmail) ? locationEmail : throw new ArgumentNullException(nameof(locationEmail));
            CityId = cityId > 0 ? cityId : throw new ArgumentNullException(nameof(cityId));
            CityName = !string.IsNullOrWhiteSpace(cityName) ? cityName : throw new ArgumentNullException(nameof(cityName));
            Country = !string.IsNullOrWhiteSpace(country) ? country : throw new ArgumentNullException(nameof(country));
        }
    }
}
