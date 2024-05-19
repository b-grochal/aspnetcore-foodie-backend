using Foodie.Common.Enums;
using Foodie.Identity.Domain.Common.ApplicationUser;
using Foodie.Identity.Domain.Common.ApplicationUser.ValueObjects;

namespace Foodie.Identity.Domain.Admins
{
    public class Admin : ApplicationUser
    {
        public Admin(string firstName, string lastName, 
            string email, string phoneNumber, string passwordHash) 
            : base(firstName, lastName, email, phoneNumber, passwordHash, 
                  ApplicationUserRole.Admin)
        {
        }

        public static Admin Create(string firstName, string lastName,
            string email, string phoneNumber, string passwordHash)
        {
            return new Admin(firstName, lastName, email, phoneNumber,
                passwordHash);
        }
    }
}
