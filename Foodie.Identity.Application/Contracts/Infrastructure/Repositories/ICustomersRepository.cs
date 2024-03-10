using Foodie.Common.Application.Contracts.Infrastructure.Repositories.Interfaces;
using Foodie.Common.Collections;
using Foodie.Identity.Domain.Customers;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface ICustomersRepository : IGenericRepository<Customer>
    {
        Task<PagedList<Customer>> GetAllAsync(int pageNumber, int pageSize, string email);
    }
}
