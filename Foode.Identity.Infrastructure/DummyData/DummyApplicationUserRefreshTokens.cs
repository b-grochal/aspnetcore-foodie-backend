using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Foode.Identity.Infrastructure.DummyData
{
    public class DummyApplicationUserRefreshTokens
    {
        public static List<ApplicationUserRefreshToken> Get()
        {
            return new List<ApplicationUserRefreshToken>
            {
                new ApplicationUserRefreshToken
                {
                    Id = DummySeed.AdminRefreshTokenId,
                    Token = null,
                    ExpirationTime = null,
                    ApplicationUserId = DummySeed.AdminId,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now
                },
                new ApplicationUserRefreshToken
                {
                    Id = DummySeed.OrderHandlerRefreshTokenId,
                    Token = null,
                    ExpirationTime = null,
                    ApplicationUserId = DummySeed.OrderHandlerId,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now
                },
                new ApplicationUserRefreshToken
                {
                    Id = DummySeed.CustomerRefreshTokenId,
                    Token = null,
                    ExpirationTime = null,
                    ApplicationUserId = DummySeed.CustomerId,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now
                }
            };
        }
    }
}
