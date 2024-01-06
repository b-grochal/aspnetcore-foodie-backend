using Foodie.Common.Domain.DomainEvents.Interfaces;

namespace Foodie.Orders.Domain.Contractors.DomainEvents
{
    public record ContractorVerifiedDomainEvent(Contractor Contractor, int OrderId) : IDomainEvent;
}
