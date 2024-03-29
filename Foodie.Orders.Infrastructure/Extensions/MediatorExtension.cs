﻿using Foodie.Common.Domain.Entities;
using Foodie.Orders.Infrastructure.Contexts;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Extensions
{
    public static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, OrdersDbContext ordersDbContext)
        {
            var domainEntities = ordersDbContext.ChangeTracker
                .Entries<DomainEntity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
                await mediator.Publish(domainEvent);
        }
    }
}
