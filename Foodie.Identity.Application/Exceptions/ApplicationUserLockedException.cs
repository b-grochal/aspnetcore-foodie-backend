using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Application.Exceptions
{
    public class ApplicationUserLockedException : BadRequestException
    {
        public ApplicationUserLockedException(string email) : base($"The application user with email {email} is locked.") { }
    }
}
