using Foodie.Common.Domain.Entities;

namespace Foodie.Common.Domain.AggregateRoots
{
    public abstract class AggregateRoot<TId, TIdType> : DomainEntity<TId>
        where TId : AggregateRootId<TIdType>
    {
        public new AggregateRootId<TIdType> Id { get; protected set; }

        protected AggregateRoot(TId id) : base(id)
        {
            Id = id;
        }
    }
}
