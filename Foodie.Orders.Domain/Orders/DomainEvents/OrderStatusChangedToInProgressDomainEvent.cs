using MediatR;

namespace Foodie.Orders.Domain.Orders.DomainEvents
{
    public class OrderStatusChangedToInProgressDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderStatusChangedToInProgressDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
