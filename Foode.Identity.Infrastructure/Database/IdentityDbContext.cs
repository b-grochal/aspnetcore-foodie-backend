using Foode.Identity.Infrastructure.Database.Configurations;
using Foodie.Common.Infrastructure.Database.Contexts;
using Foodie.Identity.Domain.Admins;
using Foodie.Identity.Domain.Common.ApplicationUser;
using Foodie.Identity.Domain.Customers;
using Foodie.Identity.Domain.OrderHandlers;
using Microsoft.EntityFrameworkCore;

namespace Foode.Identity.Infrastructure
{
    public class IdentityDbContext : BaseDbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<OrderHandler> OrderHandlers { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public IdentityDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ApplicationUserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AdminEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderHandlerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
        }
    }
}
