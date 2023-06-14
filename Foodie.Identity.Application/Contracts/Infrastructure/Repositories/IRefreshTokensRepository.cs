using Foodie.Identity.Domain.Entities;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IRefreshTokensRepository
    {
        Task<RefreshToken> CreateAsync(RefreshToken entity);
        Task UpdateAsync(RefreshToken entity);
        Task<RefreshToken> GetByApplicationUserIdAsync(int applicationUserId);
    }
}
