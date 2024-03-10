using Foodie.Common.Domain.Results;

namespace Foodie.Identity.Domain.Common.ApplicationUser.Errors
{
    public static class ApplicationUserErrors
    {
        public static Error ApplicationUserAlreadyExists(string email) => 
            Error.Conflict("ApplicationUsers.ApplicationUserAlreadyExists",
                $"The application user with email {email} already exists.");

        public static Error ApplicationUserNotFoundByEmail(string email) =>
            Error.Conflict("ApplicationUsers.ApplicationUserNotFoundByEmail",
                $"The application user with the email address {email} was not found.");

        public static Error ApplicationUserNotFoundById(int id) =>
            Error.Conflict("ApplicationUsers.ApplicationUserNotFoundById",
                $"The application user with the identifier {id} was not found.");

        public static Error ApplicationUserLocked(string email) =>
            Error.Conflict("ApplicationUsers.ApplicationUserLocked",
                $"The application user with email {email} is locked.");

        public static Error ApplicationUserNotActivated(string email) =>
            Error.Conflict("ApplicationUsers.ApplicationUserNotActivated",
                $"The application user with email {email} is not activated.");

        public static Error ApplicationUserNotAuthenticated(string email) =>
            Error.Conflict("ApplicationUsers.ApplicationUserNotAuthenticated",
                $"The application user with email {email} could not be authenticated.");
    }
}
