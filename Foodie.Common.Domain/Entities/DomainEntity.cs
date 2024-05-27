using Foodie.Common.Domain.DomainEvents.Interfaces;
using Foodie.Common.Domain.Entities.Interfaces;
using System.Collections.Generic;

namespace Foodie.Common.Domain.Entities
{
    public abstract class DomainEntity : IHasDomainEvents
    {
        public int Id { get; protected set; }

        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public bool IsDeleted { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is DomainEntity entity && Id.Equals(entity.Id);
        }

        public bool Equals(DomainEntity? other)
        {
            return Equals((object?)other);
        }

        public static bool operator ==(DomainEntity left, DomainEntity right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(DomainEntity left, DomainEntity right)
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

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
