using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Application.Contracts.Infrastructure.Services
{
    public interface IJwtService
    {
        string GenerateToken(ApplicationUser applicationUser, string applicationUserRole);
    }
}
