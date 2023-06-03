using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserNotUpdatedException : InternalServerErrorException
    {
        public ApplicationUserNotUpdatedException(string applicationUserId) : base($"The application user with the indetifier {applicationUserId} was not updated.") { }
    }
}
