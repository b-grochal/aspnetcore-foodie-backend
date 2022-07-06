using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Domain.Events
{
    public class OrderStartedDomainEvent : INotification
    {
        public string UserId { get; }
        public string UserFirstName { get; }
        public string UserLastName { get; }
        public string UserPhoneNumber { get; }
        public string UserEmail { get; }
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

        public OrderStartedDomainEvent(string userId, string userFirstName, string userLastName, string userPhoneNumber, string userEmail, int restaurantId,
            string restaurantName, int locationId, string locationAddress, string locationPhoneNumber, string locationEmail, int cityId, string cityName, string locationCountry, Order order)
        {
            UserId = userId;
            UserFirstName = userFirstName;
            UserLastName = userLastName;
            UserPhoneNumber = userPhoneNumber;
            UserEmail = userEmail;
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
