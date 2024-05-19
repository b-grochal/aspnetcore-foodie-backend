using Foodie.Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Foodie.Identity.Domain.Common.ApplicationUser.ValueObjects
{
    public class RefreshToken : ValueObject
    {
        public string Token { get; }

        public DateTimeOffset? ExpirationTime { get; }

        private RefreshToken(string token, DateTimeOffset? expirationTime)
        {
            Token = token;
            ExpirationTime = expirationTime;
        }

        public static RefreshToken Create(string token, DateTimeOffset? expirationTime)
        {
            return new RefreshToken(token, expirationTime);
        }

        public static RefreshToken CreateEmpty()
        {
            return new RefreshToken(null, null);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Token;
            yield return ExpirationTime;
        }
    }
}
