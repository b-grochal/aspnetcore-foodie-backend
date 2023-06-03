using Foodie.Identity.Domain.Entities;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Services
{
    public interface IAuthService
    {
        Task<ApplicationUser> AuthenticateUser(string email, string password);
    }
}
