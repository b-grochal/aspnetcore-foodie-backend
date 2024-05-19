using Foodie.Common.Results;

namespace Foodie.Identity.Domain.Common.ApplicationUser.Errors
{
    public static class ApplicationUserDomainErrors
    {
        public static Error SameEmailAsOldOne() =>
            Error.Failure("ApplicationUsers.SameEmailAsOldOne",
                "Email address is the same like the old one.");
        
    }
}
