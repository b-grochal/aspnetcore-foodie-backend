using Foodie.Common.Domain.DomainEvents.Interfaces;

namespace Foodie.Orders.Domain.Orders.DomainEvents
{
    public record OrderStatusChangedToInProgressDomainEvent(Order Order) : IDomainEvent;
}
