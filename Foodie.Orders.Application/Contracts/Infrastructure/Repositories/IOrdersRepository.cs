using Foodie.Orders.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Orders.Application.Contracts.Infrastructure.Repositories
{
    public interface IOrdersRepository : IRepository<Order>
    {
        Task<Order> CreateAsync(Order order);
        Task UpdateAsync(Order order);
        Task<Order> GetByIdAsync(int id);
    }
}
