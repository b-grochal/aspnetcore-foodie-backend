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
    public class SoftDeleteForBaseEntitiesInterceptor : SaveChangesInterceptor
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

            IEnumerable<EntityEntry<ISoftDeletableBaseEntity>> entries =
            eventData
            .Context
            .ChangeTracker
            .Entries<ISoftDeletableBaseEntity>()
            .Where(e => e.State == EntityState.Deleted);

            foreach (EntityEntry<ISoftDeletableBaseEntity> softDeletable in entries)
            {
                softDeletable.State = EntityState.Modified;
                softDeletable.Entity.IsDeleted = true;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
