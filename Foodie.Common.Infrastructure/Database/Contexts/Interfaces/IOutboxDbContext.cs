using Foodie.Common.Infrastructure.Database.Outbox;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Common.Infrastructure.Database.Contexts.Interfaces
{
    public interface IOutboxDbContext
    {
        public DbSet<OutboxMessage> OutboxMessages { get; set; }
    }
}
