using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Repositories;
using Foodie.Shared.Types.Pagination;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IAdminsRepository : IRepository<Admin>
    {
        Task<PagedResult<Admin>> GetAllAsync(int pageNumber, int pageSize, string email);
    }
}
