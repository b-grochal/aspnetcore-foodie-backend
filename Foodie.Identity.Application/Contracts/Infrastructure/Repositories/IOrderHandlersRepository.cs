using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IOrderHandlersRepository
    {
        Task CreateAsync(OrderHandler orderHandler);
        Task DeleteAsync(string id);
        Task UpdateAsync(OrderHandler orderHandler);
        Task<OrderHandler> GetByIdAsync(string id);
        Task<IReadOnlyList<OrderHandler>> GetAllAsync();
    }
}
