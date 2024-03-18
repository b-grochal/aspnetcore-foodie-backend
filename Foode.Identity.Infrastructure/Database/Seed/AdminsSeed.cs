using Foodie.Common.Enums;
using Foodie.Identity.Domain.Admins;
using System;
using System.Collections.Generic;

namespace Foode.Identity.Infrastructure.Database.Seed
{
    public static class AdminsSeed
    {
        public static List<Admin> Get()
        {
            return new List<Admin>
            {
                new Admin
                {
                    Id = IdentitySeed.AdminId,
                    FirstName = "Michael",
                    LastName = "Scott",
                    Email = "michsco123@foodie.com",
                    PhoneNumber = "123-456-789",
                    Role = ApplicationUserRole.Admin,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                    IsActive = true
                }
            };
        }
    }
}
