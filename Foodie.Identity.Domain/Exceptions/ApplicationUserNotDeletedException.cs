using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserNotDeletedException : InternalServerErrorException
    {
        public ApplicationUserNotDeletedException(string applicationUserId) : base($"The application user with the indetifier {applicationUserId} was not deleted.") { }
    }
}
