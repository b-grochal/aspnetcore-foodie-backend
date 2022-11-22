using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.DummyData
{
    public static class DummyOrderHandlers
    {
        public static List<OrderHandler> Get()
        {
            return new List<OrderHandler>
            {
                new OrderHandler
                {
                    Id = DummySeed.OrderHandler,
                    FirstName = "Dwight",
                    LastName = "Schrute",
                    UserName = "dwigsch123",
                    NormalizedUserName = "DWIGSCH123",
                    Email = "dwigsch123@foodie.com",
                    NormalizedEmail = "DWIGSCH123@FOODIE.COM",
                    EmailConfirmed = true,
                    PhoneNumber = "123-456-789",
                    PhoneNumberConfirmed = true
                }
            };
        }
    }
}
