using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Application.Exceptions
{
    public class ApplicationUserNotActivatedException : BadRequestException
    {
        public ApplicationUserNotActivatedException(string email) : base($"The application user with email {email} is not activated.") { }
    }
}
