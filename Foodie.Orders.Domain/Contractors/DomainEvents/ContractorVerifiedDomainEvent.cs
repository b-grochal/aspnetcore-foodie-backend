using MediatR;

namespace Foodie.Orders.Domain.Contractors.DomainEvents
{
    public class ContractorVerifiedDomainEvent : INotification
    {
        public Contractor Contractor { get; private set; }
        public int OrderId { get; private set; }

        public ContractorVerifiedDomainEvent(Contractor contractor, int orderId)
        {
            Contractor = contractor;
            OrderId = orderId;
        }
    }
}
