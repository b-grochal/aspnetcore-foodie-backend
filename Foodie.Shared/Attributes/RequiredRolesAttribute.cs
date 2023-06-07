using Foodie.Shared.Authentication;
using Foodie.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace Foodie.Shared.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RequiredRolesAttribute : Attribute, IAuthorizationFilter
    {
        private readonly ApplicationUserRole[] roles;

        public RequiredRolesAttribute(params ApplicationUserRole[] roles)
        {
            this.roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (Enum.TryParse<ApplicationUserRole>(context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ApplicationUserClaim.Role).Value, out var claimRole) && !roles.Contains(claimRole))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
