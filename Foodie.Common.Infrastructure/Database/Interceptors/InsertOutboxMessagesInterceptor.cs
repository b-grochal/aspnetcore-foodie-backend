using Foodie.Common.Domain.Entities;
using Foodie.Common.Infrastructure.Database.Contexts.Interfaces;
using Foodie.Common.Infrastructure.Database.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Database.Interceptors
{
    public sealed class InsertOutboxMessagesInterceptor : SaveChangesInterceptor
    {
        private readonly JsonSerializerSettings _jsonSerializerSettings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is not null)
            {
                InsertOutboxMessages(eventData.Context);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void InsertOutboxMessages(DbContext dbContext)
        {
            var outboxMessages = dbContext
                .ChangeTracker
                .Entries<DomainEntity>()
                .Select(entry => entry.Entity)
                .SelectMany(entity =>
                {
                    var domainEvents = entity.DomainEvents;

                    entity.ClearDomainEvents();

                    return domainEvents;
                })
                .Select(domainEvent => new OutboxMessage(
                    Guid.NewGuid(),
                    domainEvent.GetType().Name,
                    JsonConvert.SerializeObject(domainEvent, _jsonSerializerSettings),
                    DateTimeOffset.Now
                    ))
                .ToList();

            dbContext.Set<OutboxMessage>().AddRange(outboxMessages);
        }
    }
}
