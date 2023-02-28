using Foodie.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Identity.Domain.Exceptions
{
    public class ApplicationUserRoleNotFoundException : NotFoundException
    {
        public ApplicationUserRoleNotFoundException(string applicationUserId) : base($"The role for application user with the indetifier {applicationUserId} was not found.") { }
    }
}
