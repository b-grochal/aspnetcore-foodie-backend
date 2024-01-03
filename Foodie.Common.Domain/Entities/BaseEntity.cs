namespace Foodie.Common.Domain.Entities
{
    public abstract class BaseEntity<TId> where TId : notnull
    {
        public TId Id { get; set; }
    }
}
