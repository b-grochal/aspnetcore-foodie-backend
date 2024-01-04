using MediatR;

namespace Foodie.Orders.Domain.Orders.DomainEvents
{
    public class OrderStartedDomainEvent : INotification
    {
        public string CustomerId { get; }
        public string CustomerFirstName { get; }
        public string CustomerLastName { get; }
        public string CustomerPhoneNumber { get; }
        public string CustomerEmail { get; }
        public int RestaurantId { get; }
        public string RestaurantName { get; }
        public int LocationId { get; }
        public string LocationAddress { get; }
        public string LocationPhoneNumber { get; }
        public string LocationEmail { get; }
        public int CityId { get; }
        public string CityName { get; }
        public string LocationCountry { get; }
        public Order Order { get; }

        public OrderStartedDomainEvent(string customerId, string customerFirstName, string customerLastName, string customerPhoneNumber, string customerEmail, int restaurantId,
            string restaurantName, int locationId, string locationAddress, string locationPhoneNumber, string locationEmail, int cityId, string cityName, string locationCountry, Order order)
        {
            CustomerId = customerId;
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            CustomerPhoneNumber = customerPhoneNumber;
            CustomerEmail = customerEmail;
            RestaurantId = restaurantId;
            RestaurantName = restaurantName;
            LocationId = locationId;
            LocationAddress = locationAddress;
            LocationPhoneNumber = locationPhoneNumber;
            LocationEmail = locationEmail;
            CityId = cityId;
            CityName = cityName;
            LocationCountry = locationCountry;
            Order = order;
        }
    }
}
