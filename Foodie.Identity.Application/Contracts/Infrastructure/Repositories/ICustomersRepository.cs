using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface ICustomersRepository
    {
        Task CreateAsync(Customer customer);
        Task DeleteAsync(string id);
        Task UpdateAsync(Customer customer);
        Task<Customer> GetByIdAsync(string id);
        Task<IReadOnlyList<Customer>> GetAllAsync();
    }
}
