using Foode.Identity.Infrastructure.DummyData;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<OrderHandler> OrderHandlers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public IdentityDbContext(DbContextOptions options) : base(options) { }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("ApplicationUserLogins");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("ApplicationUserTokens");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("ApplicationUserClaims");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("ApplicationUserRoles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityRole<string>>().ToTable("Roles");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<OrderHandler>().ToTable("OrderHandlers");

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            foreach (var role in DummyRoles.Get())
            {
                modelBuilder.Entity<IdentityRole>().HasData(role);
            }

            foreach (var admin in DummyAdmins.Get())
            {
                admin.PasswordHash = passwordHasher.HashPassword(admin, "P@ssw0rd");
                admin.SecurityStamp = Guid.NewGuid().ToString();
                modelBuilder.Entity<Admin>().HasData(admin);
            }

            foreach (var orderHandler in DummyOrderHandlers.Get())
            {
                orderHandler.PasswordHash = passwordHasher.HashPassword(orderHandler, "P@ssw0rd");
                orderHandler.SecurityStamp = Guid.NewGuid().ToString();
                modelBuilder.Entity<OrderHandler>().HasData(orderHandler);
            }

            foreach (var customer in DummyCustomers.Get())
            {
                customer.PasswordHash = passwordHasher.HashPassword(customer, "P@ssw0rd");
                customer.SecurityStamp = Guid.NewGuid().ToString();
                modelBuilder.Entity<Customer>().HasData(customer);
            }

            foreach (var userRole in DummyUserRoles.Get())
            {
                modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRole);
            }
        }
    }
}
