using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.DummyData
{
    public static class DummyRoles
    {
        public static List<IdentityRole> Get()
        {
            return new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id=DummySeed.AdminRole,
                    Name="Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id=DummySeed.OrderHandlerRole,
                    Name="OrderHandler",
                    NormalizedName = "ORDERHANDLER"
                },
                new IdentityRole
                {
                    Id=DummySeed.CustomerRole,
                    Name="Customer",
                    NormalizedName = "CUSTOMER"
                },
            };
        }
    }
}
