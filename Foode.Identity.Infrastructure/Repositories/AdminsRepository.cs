using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class AdminsRepository : BaseIdentityRepository<Admin>, IAdminsRepository
    {
        public AdminsRepository(IdentityDbContext identityDbContext) : base(identityDbContext) { }

        public async Task<PagedResult<Admin>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            return dbContext.Admins
                .Where(c => email == null || c.Email.Equals(email))
                .Paginate(pageNumber, pageSize);
        }
    }
}
