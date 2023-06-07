using Foodie.Identity.Domain.Entities;
using Foodie.Shared.Enums;
using System;
using System.Collections.Generic;

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
                    Email = "dwigsch123@foodie.com",
                    PhoneNumber = "123-456-789",
                    Role = ApplicationUserRole.OrderHandler,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                    LocationId = DummySeed.OrderHandlerLocationId
                }
            };
        }
    }
}
