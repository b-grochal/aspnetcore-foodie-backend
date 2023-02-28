using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.DummyData
{
    public static class DummyApplicationUserRoles
    {
        public static List<IdentityUserRole<string>> Get()
        {
            return new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = DummySeed.AdminRole,
                    UserId = DummySeed.Admin
                },
                new IdentityUserRole<string>
                {
                    RoleId = DummySeed.OrderHandlerRole,
                    UserId = DummySeed.OrderHandler
                },
                new IdentityUserRole<string>
                {
                    RoleId = DummySeed.CustomerRole,
                    UserId = DummySeed.Customer
                }
            };
        }
    }
}
