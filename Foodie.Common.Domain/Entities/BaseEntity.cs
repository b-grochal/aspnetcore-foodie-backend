using Foodie.Common.Domain.Entities.Interfaces;

namespace Foodie.Common.Domain.Entities
{
    public abstract class BaseEntity : ISoftDeletableBaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
