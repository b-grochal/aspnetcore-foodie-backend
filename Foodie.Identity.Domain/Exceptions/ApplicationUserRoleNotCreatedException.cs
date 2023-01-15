using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserRoleNotCreatedException : InternalServerErrorException
    {
        public ApplicationUserRoleNotCreatedException(string applicationUserId, string roleName) : base($"The role {roleName} for application user with the indetifier {applicationUserId} was not created.") { }
    }
}
