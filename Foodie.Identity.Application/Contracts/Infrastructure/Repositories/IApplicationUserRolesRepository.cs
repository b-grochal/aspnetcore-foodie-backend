using Foodie.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Repositories
{
    public interface IApplicationUserRolesRepository
    {
        Task<IdentityResult> CreateApplicationUserRole(ApplicationUser applicationUser, string roleName);
        Task<string> GetApplicationUserRole(ApplicationUser applicationUser);
    }
}
