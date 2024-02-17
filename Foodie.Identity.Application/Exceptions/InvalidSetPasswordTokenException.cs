using Foodie.Common.Exceptions;

namespace Foodie.Identity.Application.Exceptions
{
    public class InvalidSetPasswordTokenException : BadRequestException
    {
        public InvalidSetPasswordTokenException() : base("Invalid set password token.") { }
    }
}
