using Foodie.Common.Domain.DomainEvents.Interfaces;

namespace Foodie.Orders.Domain.Buyers.DomainEvents
{
    public record BuyerVerifiedDomainEvent(Buyer Buyer, int OrderId) : IDomainEvent;
}
