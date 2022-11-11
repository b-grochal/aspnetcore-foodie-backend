using Foodie.Orders.Application.Contracts.Infrastructure.Context;
using Foodie.Orders.Application.Contracts.Infrastructure.Repositories;
using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using Foodie.Orders.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Infrastructure.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly OrdersDbContext _ordersDbContext;
        public IUnitOfWork UnitOfWork => _ordersDbContext;

        public OrdersRepository(OrdersDbContext ordersDbContext)
        {
            _ordersDbContext = ordersDbContext;
        }

        public Order Create(Order order)
        {
            return _ordersDbContext.Orders.Add(order).Entity;
        }

        public void Update(Order order)
        {
            _ordersDbContext.Entry(order).State = EntityState.Modified;
        }

        public Task<Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
