using Foodie.Common.Domain.DomainEvents.Interfaces;
using System.Collections.Generic;

namespace Foodie.Common.Domain.Entities
{
    public abstract class DomainEntity<TId> : AuditableEntity<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected DomainEntity(TId id)
        {
            Id = id;
        }

        public override bool Equals(object? obj)
        {
            return obj is DomainEntity<TId> entity && Id.Equals(entity.Id);
        }

        public bool Equals(DomainEntity<TId>? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(DomainEntity<TId> left, DomainEntity<TId> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DomainEntity<TId> left, DomainEntity<TId> right)
        {
            return !Equals(left, right);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
