using MediatR;

namespace Foodie.Orders.Domain.Orders.DomainEvents
{
    public class OrderDeliveredDomainEvent : INotification
    {
        public Order Order { get; }

        public OrderDeliveredDomainEvent(Order order)
        {
            Order = order;
        }
    }
}
