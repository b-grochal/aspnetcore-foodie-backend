using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Application.Exceptions
{
    public class SameEmailAsOldOneException : BadRequestException
    {
        public SameEmailAsOldOneException() : base("Email address is the same like the old one.") { }
    }
}
