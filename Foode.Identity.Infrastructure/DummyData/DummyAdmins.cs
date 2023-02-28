using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Id = DummySeed.Admin,
                    FirstName = "Michael",
                    LastName = "Scott",
                    UserName = "michsco123",
                    NormalizedUserName = "MICHSCO123@FOODIE.COM",
                    Email = "michsco123@foodie.com",
                    NormalizedEmail = "MICHSCO123@FOODIE.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "123-456-789",
                    PhoneNumberConfirmed = true,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now
                }
            };
        }
    }
}
