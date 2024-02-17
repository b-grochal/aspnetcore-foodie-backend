using Foodie.Common.Domain.DomainEvents.Interfaces;

namespace Foodie.Orders.Domain.Orders.DomainEvents
{
    public record OrderStartedDomainEvent(string CustomerId, string CustomerFirstName, string CustomerLastName, string CustomerPhoneNumber,
        string CustomerEmail, int RestaurantId, string RestaurantName, int LocationId, string LocationAddress, string LocationPhoneNumber,
        string LocationEmail, int CityId, string CityName, int CountryId, string CountryName, Order Order) : IDomainEvent;
    
}
