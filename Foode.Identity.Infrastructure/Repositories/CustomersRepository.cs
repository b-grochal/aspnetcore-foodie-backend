using Foodie.Identity.Application.Contracts.Infrastructure.Repositories;
using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Types.Pagination;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Repositories
{
    public class CustomersRepository : BaseIdentityRepository<Customer>, ICustomersRepository
    {
        public CustomersRepository(IdentityDbContext identityDbContext) : base(identityDbContext) { }

        public async Task<PagedResult<Customer>> GetAllAsync(int pageNumber, int pageSize, string email)
        {
            return dbContext.Customers
                .Where(c => email == null || c.Email.Equals(email))
                .Paginate(pageNumber, pageSize);
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await dbContext.Customers
                .FirstOrDefaultAsync(c => c.Email == email);
        }
    }
}
