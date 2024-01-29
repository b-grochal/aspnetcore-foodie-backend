using Foodie.Common.Exceptions;

namespace Foodie.Identity.Application.Exceptions
{
    public class ApplicationUserAlreadyExistsException : BadRequestException
    {
        public ApplicationUserAlreadyExistsException(string email) : base($"The application user with email {email} already exists.") { }
    }
}
