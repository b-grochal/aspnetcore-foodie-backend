using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserNotAuthenticatedException : BadRequestException
    {
        public ApplicationUserNotAuthenticatedException(string email) : base($"The application user with email {email} could not be authenticated.") { }
    }
}
