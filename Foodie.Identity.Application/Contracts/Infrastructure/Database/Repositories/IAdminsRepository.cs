using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Common.Collections;
using Foodie.Identity.Domain.Admins;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Database.Repositories
{
    public interface IAdminsRepository : IGenericRepository<Admin>
    {
        Task<PagedList<Admin>> GetAllAsync(int pageNumber, int pageSize, string email);
    }
}
