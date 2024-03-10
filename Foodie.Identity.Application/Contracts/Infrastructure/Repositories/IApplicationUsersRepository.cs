using Foodie.Identity.Domain.Common.ApplicationUser;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IApplicationUsersRepository
    {
        Task<ApplicationUser> GetByEmailAsync(string email);
        Task<ApplicationUser> GetByIdAsync(int id);
        Task UpdateAsync(ApplicationUser entity);

        Task<bool> IsEmailUniqueAsync(string email);
    }
}
