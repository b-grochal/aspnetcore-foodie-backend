using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface ICustomersRepository
    {
        Task CreateAsync(Customer customer, string password);
        Task DeleteAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task<Customer> GetByIdAsync(string id);
        Task<IReadOnlyList<Customer>> GetAllAsync();
        Task<PagedList<Customer>> GetAllAsync(int pageNumber, int pageSize, string email);
    }
}
