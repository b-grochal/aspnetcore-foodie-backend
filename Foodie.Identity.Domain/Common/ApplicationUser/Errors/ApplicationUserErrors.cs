using Foodie.Common.Domain.Results;

namespace Foodie.Identity.Domain.Common.ApplicationUser.Errors
{
    public static class ApplicationUserErrors
    {
        public static Error ApplicationUserAlreadyExists(string email) => 
            Error.Conflict("ApplicationUsers.ApplicationUserAlreadyExists",
                $"The application user with email {email} already exists.");
    }
}
