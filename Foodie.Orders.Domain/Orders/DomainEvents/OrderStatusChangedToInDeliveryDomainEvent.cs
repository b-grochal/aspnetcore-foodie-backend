using MediatR;

namespace Foodie.Orders.Domain.Orders.DomainEvents
{
    public class OrderStatusChangedToInDeliveryDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderStatusChangedToInDeliveryDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
