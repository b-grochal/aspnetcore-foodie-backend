using Foodie.Common.Enums;
using Foodie.Identity.Domain.OrderHandlers;
using System;
using System.Collections.Generic;

namespace Foode.Identity.Infrastructure.Database.Seed
{
    public static class OrderHandlersSeed
    {
        public static List<OrderHandler> Get()
        {
            return new List<OrderHandler>
            {
                new OrderHandler
                {
                    Id = IdentitySeed.OrderHandlerId,
                    FirstName = "Dwight",
                    LastName = "Schrute",
                    Email = "dwigsch123@foodie.com",
                    PhoneNumber = "123-456-789",
                    Role = ApplicationUserRole.OrderHandler,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now,
                    LocationId = IdentitySeed.OrderHandlerLocationId,
                    IsActive = true
                }
            };
        }
    }
}
