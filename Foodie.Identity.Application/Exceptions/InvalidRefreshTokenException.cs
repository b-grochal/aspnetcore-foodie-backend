using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Application.Exceptions
{
    public class InvalidRefreshTokenException : BadRequestException
    {
        public InvalidRefreshTokenException() : base("Invalid refresh token.") { }
    }
}
