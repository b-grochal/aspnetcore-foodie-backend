using Foodie.Common.Results;

namespace Foodie.Identity.Application.Features.Auth.Errors
{
    public static class AuthErrors
    { 
        public static Error ApplicationUserLocked(string email) =>
            Error.Failure("ApplicationUsers.ApplicationUserLocked",
                $"The application user with email {email} is locked.");

        public static Error ApplicationUserNotActivated(string email) =>
            Error.Failure("ApplicationUsers.ApplicationUserNotActivated",
                $"The application user with email {email} is not activated.");

        public static Error ApplicationUserNotAuthenticated(string email) =>
            Error.Failure("ApplicationUsers.ApplicationUserNotAuthenticated",
                $"The application user with email {email} could not be authenticated.");

        public static Error RefreshTokenNotFound(int applicationUserId) =>
            Error.NotFound("ApplicationUsers.RefreshTokenNotFound",
                $"The refresh token for application user with the identifier {applicationUserId} was not found.");

        public static Error InvalidRefreshToken() =>
            Error.Failure("ApplicationUsers.InvalidRefreshToken",
                "Invalid refresh token.");
    }
}
