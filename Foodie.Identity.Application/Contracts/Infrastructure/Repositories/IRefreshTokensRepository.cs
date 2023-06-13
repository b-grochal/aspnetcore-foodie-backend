using Foodie.Identity.Domain.Entities;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IRefreshTokensRepository
    {
        Task<ApplicationUserRefreshToken> CreateAsync(ApplicationUserRefreshToken entity);
        Task UpdateAsync(ApplicationUserRefreshToken entity);
        Task<ApplicationUserRefreshToken> GetByApplicationUserIdAsync(int applicationUserId);
    }
}
