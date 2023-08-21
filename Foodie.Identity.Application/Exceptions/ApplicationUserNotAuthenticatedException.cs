using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Application.Exceptions
{
    public class ApplicationUserNotAuthenticatedException : BadRequestException
    {
        public ApplicationUserNotAuthenticatedException(string email) : base($"The application user with email {email} could not be authenticated.") { }
    }
}
