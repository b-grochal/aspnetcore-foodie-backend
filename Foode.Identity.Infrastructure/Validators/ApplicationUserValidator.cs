using Foodie.Identity.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foode.Identity.Infrastructure.Validators
{
    public class ApplicationUserValidator : UserValidator<ApplicationUser>
    {
        public override async Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser applicationUser)
        {
            var result = await base.ValidateAsync(manager, applicationUser);

            List<IdentityError> errors = result.Succeeded ? new List<IdentityError>() : result.Errors.ToList();

            if((applicationUser is Admin || applicationUser is OrderHandler) && !applicationUser.Email.EndsWith("@foodie.com"))
            {
                errors.Add(new IdentityError
                {
                    Description = "Only emails in foodie.com domain are allowed for admins and order handlers"
                });
            }

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
