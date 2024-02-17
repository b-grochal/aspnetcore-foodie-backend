using Foodie.Common.Collections;
using Foodie.Common.Linq;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class AdminsRepository : BaseIdentityRepository<Admin>, IAdminsRepository
    {
        public AdminsRepository(IdentityDbContext identityDbContext) : base(identityDbContext) { }

        public async Task<PagedList<Admin>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            return dbContext.Admins
                .Where(c => email == null || c.Email.Equals(email))
                .Paginate(pageNumber, pageSize);
        }
    }
}
