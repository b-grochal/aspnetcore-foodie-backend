using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserNotFoundException : NotFoundException
    {
        public ApplicationUserNotFoundException(int applicationUserId) : base($"The application user with the indetifier {applicationUserId} was not found.") { }
        public ApplicationUserNotFoundException(string applicationUserEmail) : base($"The application user with the email address {applicationUserEmail} was not found.") { }
    }
}
