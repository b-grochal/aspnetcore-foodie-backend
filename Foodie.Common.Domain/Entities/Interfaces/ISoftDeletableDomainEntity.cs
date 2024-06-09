namespace Foodie.Common.Domain.Entities.Interfaces
{
    public interface ISoftDeletableDomainEntity
    {
        bool IsDeleted { get; }

        void MarkAsDeleted();
    }
}
