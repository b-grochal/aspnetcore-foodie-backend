using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserRefreshTokenForApplicationUserNotFoundException : NotFoundException
    {
        public ApplicationUserRefreshTokenForApplicationUserNotFoundException(int applicationUserId) : base($"The refresh token for application user with the identifier {applicationUserId} was not found") { }
    }
}
