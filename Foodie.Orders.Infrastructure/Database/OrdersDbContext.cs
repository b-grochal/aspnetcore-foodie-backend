using Foodie.Common.Infrastructure.Database.Contexts;
using Foodie.Common.Infrastructure.Database.Outbox;
using Foodie.Orders.Domain.Buyers;
using Foodie.Orders.Domain.Contractors;
using Foodie.Orders.Domain.Orders;
using Foodie.Orders.Domain.Orders.Entities;
using Foodie.Orders.Infrastructure.Database.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Database
{
    public class OrdersDbContext : BaseDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItem { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContractorEntityTypeConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
