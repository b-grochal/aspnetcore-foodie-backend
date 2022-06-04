using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IAdminsRepository
    {
        Task CreateAsync(Admin admin, string password);
        Task DeleteAsync(Admin admin);
        Task UpdateAsync(Admin admin);
        Task<Admin> GetByIdAsync(string id);
        Task<IReadOnlyList<Admin>> GetAllAsync();
        Task<PagedList<Admin>> GetAllAsync(int pageNumber, int pageSize, string email);
    }
}
