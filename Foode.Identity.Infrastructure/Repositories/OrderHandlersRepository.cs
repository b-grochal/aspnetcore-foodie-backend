using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class OrderHandlersRepository : BaseIdentityRepository<OrderHandler>, IOrderHandlersRepository
    {
        public OrderHandlersRepository(IdentityDbContext identityDbContext) : base(identityDbContext) { }

        public async Task<PagedResult<OrderHandler>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            return dbContext.OrderHandlers
                .Where(c => email == null || c.Email.Equals(email))
                .Paginate(pageNumber, pageSize);
        }

        public async Task<OrderHandler> GetByEmailAsync(string email)
        {
            return await dbContext.OrderHandlers
                .FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
