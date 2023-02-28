using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserNotCreatedException : InternalServerErrorException
    {
        public ApplicationUserNotCreatedException() : base($"The new application user was not created.") { }
    }
}
