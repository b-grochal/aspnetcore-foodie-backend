using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IAdminsRepository
    {
        Task CreateAsync(OrderHandler admin);
        Task DeleteAsync(OrderHandler admin);
        Task UpdateAsync(OrderHandler admin);
        Task<OrderHandler> GetByIdAsync(string id);
        Task<IReadOnlyList<OrderHandler>> GetAllAsync();
        Task<PagedList<OrderHandler>> GetAllAsync(int pageNumber, int pageSize, string email);
    }
}
