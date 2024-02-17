using Foodie.Common.Domain.DomainEvents.Interfaces;

namespace Foodie.Orders.Domain.Orders.DomainEvents
{
    public record OrderStatusChangedToInDeliveryDomainEvent(Order Order) : IDomainEvent;
}
