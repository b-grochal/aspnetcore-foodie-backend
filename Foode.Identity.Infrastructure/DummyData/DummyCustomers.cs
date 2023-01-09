using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.DummyData
{
    public static class DummyCustomers
    {
        public static List<Customer> Get()
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = DummySeed.Customer,
                    FirstName = "Jim",
                    LastName = "Halpert",
                    UserName = "jimhal123",
                    NormalizedUserName = "JIMHAL123@FOODIE.COM",
                    Email = "jimhal123@foodie.com",
                    NormalizedEmail = "JIMHAL123@FOODIE.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "123-456-789",
                    PhoneNumberConfirmed = true
                }
            };
        }
    }
}
