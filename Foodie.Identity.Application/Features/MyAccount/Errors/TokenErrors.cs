using Foodie.Common.Results;

namespace Foodie.Identity.Application.Features.MyAccount.Errors
{
    public static class TokenErrors
    {
        public static Error InvalidAccountActivationToken() =>
            Error.Failure("ApplicationUsers.InvalidAccountActivationToken",
                "Invalid account activation token.");

        public static Error InvalidSetPasswordToken() =>
            Error.Failure("ApplicationUsers.InvalidSetPasswordToken",
                "Invalid set password token.");
    }
}
