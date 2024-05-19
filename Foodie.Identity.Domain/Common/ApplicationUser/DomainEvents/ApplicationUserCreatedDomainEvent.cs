using Foodie.Common.Domain.DomainEvents.Interfaces;

namespace Foodie.Identity.Domain.Common.ApplicationUser.DomainEvents
{
    public record ApplicationUserCreatedDomainEvent(string ApplicationUserEmail) : IDomainEvent;
}
