using Foodie.Identity.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Foode.Identity.Infrastructure.DummyData
{
    public class DummyRefreshTokens
    {
        public static List<RefreshToken> Get()
        {
            return new List<RefreshToken>
            {
                new RefreshToken
                {
                    Id = DummySeed.AdminRefreshTokenId,
                    Token = null,
                    ExpirationTime = null,
                    ApplicationUserId = DummySeed.AdminId,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now
                },
                new RefreshToken
                {
                    Id = DummySeed.OrderHandlerRefreshTokenId,
                    Token = null,
                    ExpirationTime = null,
                    ApplicationUserId = DummySeed.OrderHandlerId,
                    CreatedBy = "Seed",
                    CreatedDate = DateTimeOffset.Now
                },
                new RefreshToken
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
