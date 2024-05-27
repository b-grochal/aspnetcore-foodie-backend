namespace Foodie.Common.Domain.Entities.Interfaces
{
    public interface ISoftDeletableBaseEntity
    {
        bool IsDeleted { get; set; }
    }
}
