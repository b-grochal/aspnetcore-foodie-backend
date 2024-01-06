using Foodie.Common.Domain.DomainEvents.Interfaces;

namespace Foodie.Orders.Domain.Orders.DomainEvents
{
    public record OrderCancelledDomainEvent(Order Order) : IDomainEvent;
}
