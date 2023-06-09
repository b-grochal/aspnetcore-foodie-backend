using Foodie.Shared.Exceptions;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserNotCreatedException : InternalServerErrorException
    {
        public ApplicationUserNotCreatedException() : base($"The new application user was not created.") { }
    }
}
