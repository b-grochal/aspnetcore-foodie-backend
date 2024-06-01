using Foodie.Common.Infrastructure.Database.Outbox.Interfaces;
using Newtonsoft.Json;

namespace Foodie.Common.Infrastructure.Database.Outbox
{
    public sealed class ProcessOutboxMessagesJob : IProcessOutboxMessagesJob
    {
        private const int BatchSize = 10;
        private readonly JsonSerializerSettings _jsonSerializerSettings = new()
        {
            TypeNameHandling = TypeNameHandling.All
        };

    }
}
