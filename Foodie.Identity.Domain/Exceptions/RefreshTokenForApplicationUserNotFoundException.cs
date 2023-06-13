using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Domain.Exceptions
{
    public class RefreshTokenForApplicationUserNotFoundException : NotFoundException
    {
        public RefreshTokenForApplicationUserNotFoundException(int applicationUserId) : base($"The refresh token for application user with the identifier {applicationUserId} was not found") { }
    }
}
