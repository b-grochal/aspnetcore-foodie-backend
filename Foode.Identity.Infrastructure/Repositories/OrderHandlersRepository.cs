using Foodie.Common.Collections;
using Foodie.Common.Linq;
using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.OrderHandlers;
using System.Linq;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class OrderHandlersRepository : BaseIdentityRepository<OrderHandler>, IOrderHandlersRepository
    {
        public OrderHandlersRepository(IdentityDbContext identityDbContext) : base(identityDbContext) { }

        public async Task<PagedList<OrderHandler>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            return dbContext.OrderHandlers
                .Where(c => email == null || c.Email.Equals(email))
                .Paginate(pageNumber, pageSize);
        }
    }
}
