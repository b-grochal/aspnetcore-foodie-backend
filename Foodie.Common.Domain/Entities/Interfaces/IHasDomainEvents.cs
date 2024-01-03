using Foodie.Common.Domain.DomainEvents.Interfaces;
using System.Collections.Generic;

namespace Foodie.Common.Domain.Entities.Interfaces
{
    public interface IHasDomainEvents
    {
        public IReadOnlyList<IDomainEvent> DomainEvents { get; }
        public void ClearDomainEvents();
    }
}
