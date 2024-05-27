using Foodie.Common.Domain.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Database.Interceptors
{
    public class SoftDeleteForDomainEntitiesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null)
            {
                return base.SavingChangesAsync(
                eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<ISoftDeletableDomainEntity>> entries =
            eventData
            .Context
            .ChangeTracker
            .Entries<ISoftDeletableDomainEntity>()
            .Where(e => e.State == EntityState.Deleted);

            foreach (EntityEntry<ISoftDeletableDomainEntity> softDeletable in entries)
            {
                softDeletable.State = EntityState.Modified;
                softDeletable.Entity.MarkAsDeleted();
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}