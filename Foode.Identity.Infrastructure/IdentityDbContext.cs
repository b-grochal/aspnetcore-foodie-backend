using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Entities;
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
        public DbSet<Admin> OrderHandlers { get; set; }
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

            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<OrderHandler>().ToTable("OrderHandlers");

            foreach (var role in DummyRoles.Get())
            {
                modelBuilder.Entity<IdentityRole<int>>().HasData(role);
            }

            foreach (var teacher in DummyTeachers.Get())
            {
                teacher.PasswordHash = passwordHasher.HashPassword(teacher, "P@ssw0rd");
                teacher.SecurityStamp = Guid.NewGuid().ToString();
                modelBuilder.Entity<IdentityTeacher>().HasData(teacher);
            }

            foreach (var userRole in DummyUserRoles.Get())
            {
                modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRole);
            }
        }
    }
}
