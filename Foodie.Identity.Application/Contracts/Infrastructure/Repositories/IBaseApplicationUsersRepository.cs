using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Extensions;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IBaseApplicationUsersRepository<T> where T : ApplicationUser
    {
        Task<IdentityResult> CreateAsync(T applicationUser, string password);
        Task<IdentityResult> DeleteAsync(T applicationUser);
        Task<IdentityResult> UpdateAsync(T applicationUser);
        Task<T> GetByIdAsync(string id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<PagedList<T>> GetAllAsync(int pageNumber, int pageSize, string email);
    }
}
