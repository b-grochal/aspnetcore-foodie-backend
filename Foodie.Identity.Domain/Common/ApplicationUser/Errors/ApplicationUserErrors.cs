using Foodie.Common.Domain.Results;

namespace Foodie.Identity.Domain.Common.ApplicationUser.Errors
{
    public static class ApplicationUserErrors
    {
        public static Error ApplicationUserAlreadyExists(string email) => 
            Error.Conflict("ApplicationUsers.ApplicationUserAlreadyExists",
                $"The application user with email {email} already exists.");

        public static Error ApplicationUserNotFoundByEmail(string email) =>
            Error.NotFound("ApplicationUsers.ApplicationUserNotFoundByEmail",
                $"The application user with the email address {email} was not found.");

        public static Error ApplicationUserNotFoundById(int id) =>
            Error.NotFound("ApplicationUsers.ApplicationUserNotFoundById",
                $"The application user with the identifier {id} was not found.");

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
