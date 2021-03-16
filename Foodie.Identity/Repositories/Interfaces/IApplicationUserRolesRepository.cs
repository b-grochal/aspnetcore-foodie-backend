using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Repositories.Interfaces
{
    public interface IApplicationUserRolesRepository
    {
        Task<string> GetApplicationUserRole(string id);
    }
}
