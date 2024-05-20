using Foodie.Common.Infrastructure.Database.Audits;
using Microsoft.EntityFrameworkCore;

namespace Foodie.Common.Infrastructure.Database.Contexts
{
    public class BaseDbContext : DbContext
    {
        public DbSet<Audit> Audits { get; set; }

        public void PrepareAuditsForEntities()
        {
            
        }
    }
}
