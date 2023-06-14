using Foode.Identity.Infrastructure.DummyData;
using Foode.Identity.Infrastructure.Services;
using Foodie.Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure
{
    public class IdentityDbContext : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<OrderHandler> OrderHandlers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public IdentityDbContext(DbContextOptions options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<ApplicationUser>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTimeOffset.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<OrderHandler>().ToTable("OrderHandlers");
            modelBuilder.Entity<Customer>().ToTable("Customers");

            var passwordService = new PasswordService();

            foreach (var admin in DummyAdmins.Get())
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
