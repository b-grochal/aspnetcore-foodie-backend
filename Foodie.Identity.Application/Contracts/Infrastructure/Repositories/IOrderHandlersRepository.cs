using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Common.Collections;
using Foodie.Identity.Domain.Entities;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IOrderHandlersRepository : IGenericRepository<OrderHandler>
    {
        Task<PagedList<OrderHandler>> GetAllAsync(int pageNumber, int pageSize, string email);
    }
}
