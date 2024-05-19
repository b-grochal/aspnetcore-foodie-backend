using Foodie.Identity.Application.Contracts.Infrastructure.ApplicationUserUtilities;
using System;

namespace Foode.Identity.Infrastructure.ApplicationUserUtilities
{
    public class AccountTokensService : IAccountTokensService
    {
        public string GenerateAccountActivationToken()
        {
            return Guid.NewGuid().ToString();
        }

        public string GenerateSetPasswordToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
