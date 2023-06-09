using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserLockedException : BadRequestException
    {
        public ApplicationUserLockedException(string email) : base($"The application user with email {email} is locked.") { }
    }
}
