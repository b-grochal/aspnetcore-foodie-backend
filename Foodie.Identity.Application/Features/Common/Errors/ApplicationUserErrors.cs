using Foodie.Common.Results;

namespace Foodie.Identity.Application.Features.Common
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
    }
}
