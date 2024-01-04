using Foodie.Common.Domain.DomainEvents.Interfaces;

namespace Foodie.Orders.Domain.Buyers.DomainEvents
{
    public class BuyerVerifiedDomainEvent : IDomainEvent
    {
        public Buyer Buyer { get; private set; }
        public int OrderId { get; private set; }

        public BuyerVerifiedDomainEvent(Buyer buyer, int orderId)
        {
            Buyer = buyer;
            OrderId = orderId;
        }
    }
}
