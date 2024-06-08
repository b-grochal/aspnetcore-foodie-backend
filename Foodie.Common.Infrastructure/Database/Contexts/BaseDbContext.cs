using Foodie.Common.Infrastructure.Database.Audits;
using Foodie.Common.Infrastructure.Database.Contexts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Common.Infrastructure.Database.Contexts
{
    public class BaseDbContext : DbContext, IDbContext
    {
        public DbSet<Audit> Audits { get; set; }

        public BaseDbContext(DbContextOptions options) : base(options) { }

        // TODO: refactor methods for preparing audits, extract common code
        public void PrepareAuditsForEntities(int applicationUserId, string applicationUserEmail, string handlerName)
        {
            var modifiedEntites = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added
                || e.State == EntityState.Modified
                || e.State == EntityState.Deleted)
                .ToList();

            var audits = new List<Audit>();

            foreach (var modifiedEntity in modifiedEntites)
            {
                var audit = new Audit
                {
                    TableName = modifiedEntity.Entity.GetType().Name,
                    ModifiedBy = $"ApplicationUserId: {applicationUserId}, ApplicationUserEmail: {applicationUserEmail}, Handler: {handlerName}"
                };

                switch(modifiedEntity.State)
                {
                    case EntityState.Added:
                        audit.Type = AuditType.Create;
                        audit.NewValues = GetNewValues(modifiedEntity);
                        break;
                    case EntityState.Modified:
                        audit.Type = AuditType.Update;
                        audit.NewValues = GetNewValues(modifiedEntity);
                        audit.OldValues = GetOldValues(modifiedEntity);
                        audit.ModifiedColumns = GetChangedColumns(modifiedEntity);
                        break;
                    case EntityState.Deleted:
                        audit.Type = AuditType.Delete;
                        audit.OldValues = GetOldValues(modifiedEntity);
                        break;
                }

                audits.Add(audit);
            }

            Audits.AddRange(audits);
        }

        public void PrepareAuditsForEntities(string handlerName)
        {
            var modifiedEntites = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added
                || e.State == EntityState.Modified
                || e.State == EntityState.Deleted)
                .ToList();

            var audits = new List<Audit>();

            foreach (var modifiedEntity in modifiedEntites)
            {
                var audit = new Audit
                {
                    TableName = modifiedEntity.Entity.GetType().Name,
                    ModifiedBy = $"Handler: {handlerName}"
                };

                switch (modifiedEntity.State)
                {
                    case EntityState.Added:
                        audit.Type = AuditType.Create;
                        audit.NewValues = GetNewValues(modifiedEntity);
                        break;
                    case EntityState.Modified:
                        audit.Type = AuditType.Update;
                        audit.NewValues = GetNewValues(modifiedEntity);
                        audit.OldValues = GetOldValues(modifiedEntity);
                        audit.ModifiedColumns = GetChangedColumns(modifiedEntity);
                        break;
                    case EntityState.Deleted:
                        audit.Type = AuditType.Delete;
                        audit.OldValues = GetOldValues(modifiedEntity);
                        break;
                }
            }

            Audits.AddRangeAsync(audits);
        }

        private string GetOldValues(EntityEntry entityEntry)
        {
            var oldValues = new Dictionary<string, object>();

            foreach(var property in entityEntry.Properties)
            {
                oldValues[property.Metadata.Name] = property.OriginalValue;
            }

            return oldValues.Count == 0 ? null : JsonSerializer.Serialize(oldValues);
        }

        private string GetNewValues(EntityEntry entityEntry)
        {
            var newValues = new Dictionary<string, object>();

            foreach (var property in entityEntry.Properties)
            {
                newValues[property.Metadata.Name] = property.CurrentValue;
            }

            return newValues.Count == 0 ? null : JsonSerializer.Serialize(newValues);
        }

        private string GetChangedColumns(EntityEntry entityEntry)
        {
            var changedCloumns = new List<string>();

            foreach (var property in entityEntry.Properties.Where(p => p.IsModified))
            {
                changedCloumns.Add(property.Metadata.Name);
            }

            return changedCloumns.Count == 0 ? null : JsonSerializer.Serialize(changedCloumns);
        }

        public Task<int> CommitChangesAsync(string handlerName, CancellationToken cancellationToken)
        {
            PrepareAuditsForEntities(handlerName);
            return base.SaveChangesAsync(cancellationToken);
        }

        public Task<int> CommitChangesAsync(int applicationUserId, string applicationUserEmail, string handlerName, CancellationToken cancellationToken)
        {
            PrepareAuditsForEntities(applicationUserId, applicationUserEmail, handlerName);
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
