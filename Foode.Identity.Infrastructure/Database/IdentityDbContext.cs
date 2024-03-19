using Foode.Identity.Infrastructure.Database.Configurations;
using Foode.Identity.Infrastructure.Database.Seed;
using Foodie.Common.Domain.Entities;
using Foodie.Common.Domain.Entities.Interfaces;
using Foodie.Common.Infrastructure.Database.Interfaces;
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

            var passwordService = new PasswordService();

            foreach (var admin in AdminsSeed.Get())
            {
                admin.PasswordHash = passwordService.HashPassword("P@ssw0rd");
                modelBuilder.Entity<Admin>().HasData(admin);
            }

            foreach (var orderHandler in DummyOrderHandlers.Get())
            {
                orderHandler.PasswordHash = passwordService.HashPassword("P@ssw0rd");
                modelBuilder.Entity<OrderHandler>().HasData(orderHandler);
            }

            foreach (var customer in DummyCustomers.Get())
            {
                customer.PasswordHash = passwordService.HashPassword("P@ssw0rd");
                modelBuilder.Entity<Customer>().HasData(customer);
            }

            foreach (var refreshToken in DummyRefreshTokens.Get())
            {
                modelBuilder.Entity<RefreshToken>().HasData(refreshToken);
            }
        }
    }
}
