using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Enums;
using System;
using System.Collections.Generic;
namespace Foode.Identity.Infrastructure.DummyData
{
    public static class DummyAdmins
    {
        public static List<Admin> Get()
        {
            return new List<Admin>
            {
                new Admin
                {
                    Id = DummySeed.AdminId,
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
