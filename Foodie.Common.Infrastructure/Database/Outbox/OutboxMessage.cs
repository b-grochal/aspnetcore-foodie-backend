using System;

namespace Foodie.Common.Infrastructure.Database.Outbox
{
    public sealed record OutboxMessage(
        Guid Id,
        string Type,
        string Content,
        DateTimeOffset OccurrenceDate,
        DateTimeOffset? ProcessedDate = null,
        string Error = null);
}
