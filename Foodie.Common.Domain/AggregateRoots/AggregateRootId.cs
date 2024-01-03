using Foodie.Common.Domain.ValueObjects;

namespace Foodie.Common.Domain.AggregateRoots
{
    public abstract class AggregateRootId<TId> : ValueObject
    {
        public abstract TId Value { get; protected set; }
    }
}
