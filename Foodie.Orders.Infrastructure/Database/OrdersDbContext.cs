﻿using Foodie.Common.Domain.Entities.Interfaces;
using Foodie.Common.Infrastructure.Database.Contexts.Interfaces;
using Foodie.Orders.Domain.Buyers;
using Foodie.Orders.Domain.Contractors;
using Foodie.Orders.Domain.Orders;
using Foodie.Orders.Domain.Orders.Entities;
using Foodie.Orders.Infrastructure.Database.Configurations;
using Foodie.Orders.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Database
{
    public class OrdersDbContext : DbContext, IDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrdersItem { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Contractor> Contractors { get; set; }

        private readonly IMediator _mediator;

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

        public OrdersDbContext(DbContextOptions<OrdersDbContext> options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContractorEntityTypeConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEventsAsync(this);

            return await base.SaveChangesAsync(cancellationToken);
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
