using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Domain.Exceptions
{
    public class InvalidRefreshTokenException : BadRequestException
    {
        public InvalidRefreshTokenException() : base("Invalid refresh token.") { }
    }
}
