using Foodie.Common.Domain.DomainEvents.Interfaces;

namespace Foodie.Orders.Domain.Orders.DomainEvents
{
    public record OrderDeliveredDomainEvent(Order Order) : IDomainEvent;
}
