using Foodie.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Repositories.Interfaces
{
    public interface IApplicationUsersRepository
    {
        Task CreateApplicationUser(ApplicationUser applicationUser, string applicationUserRole);
        Task DeleteApplicationUser(string id);
        Task EditApplicationUser(ApplicationUser applicationUser);
        Task<ApplicationUser> GetApplicationUser(string id);
        Task<IEnumerable<ApplicationUser>> GetApplicationUsers(string applicationUserRole);
    }
}
