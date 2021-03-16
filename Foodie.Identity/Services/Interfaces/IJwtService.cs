using Foodie.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foodie.Identity.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(string applicationUserId, string applicationUserRole);
    }
}
