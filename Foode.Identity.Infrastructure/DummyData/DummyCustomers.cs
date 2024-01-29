using Foodie.Common.Enums;
using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;

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
                    Id = DummySeed.CustomerId,
                    FirstName = "Jim",
                    LastName = "Halpert",
                    Email = "jimhal123@foodie.com",
                    PhoneNumber = "123-456-789",
                    Role = ApplicationUserRole.Customer,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                    IsActive = true
                }
            };
        }
    }
}
