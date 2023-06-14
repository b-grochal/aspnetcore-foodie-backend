using Foodie.Identity.Domain.Entities;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IApplicationUsersRepository
    {
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<ApplicationUser> GetByIdAsync(int id);
        Task UpdateAsync(ApplicationUser entity);
    }
}
