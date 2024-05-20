using Foode.Identity.Infrastructure.Database.Configurations;
using Foodie.Common.Domain.Entities.Interfaces;
using Foodie.Common.Infrastructure.Database.Contexts.Interfaces;
using Foodie.Identity.Domain.Admins;
using Foodie.Identity.Domain.Common.ApplicationUser;
using Foodie.Identity.Domain.Customers;
using Foodie.Identity.Domain.OrderHandlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure
{
    public class IdentityDbContext : DbContext, IDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<OrderHandler> OrderHandlers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public IdentityDbContext(DbContextOptions options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<ApplicationUser>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property(nameof(IIsAuditable.CreatedDate)).CurrentValue = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Property(nameof(IIsAuditable.CreatedDate)).CurrentValue = DateTimeOffset.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AdminEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderHandlerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        }

        public Task<int> CommitChangesAsync(string user, CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<IIsAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property(nameof(IIsAuditable.CreatedDate)).CurrentValue = DateTimeOffset.Now;
                        entry.Property(nameof(IIsAuditable.CreatedBy)).CurrentValue = user;
                        break;
                    case EntityState.Modified:
                        entry.Property(nameof(IIsAuditable.LastModifiedDate)).CurrentValue = DateTimeOffset.Now;
                        entry.Property(nameof(IIsAuditable.LastModifiedBy)).CurrentValue = user;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
