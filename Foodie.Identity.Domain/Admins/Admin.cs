using Foodie.Common.Enums;
using Foodie.Identity.Domain.Common.ApplicationUser;
using Foodie.Identity.Domain.Common.ApplicationUser.ValueObjects;

namespace Foodie.Identity.Domain.Admins
{
    public class Admin : ApplicationUser
    {
        public Admin(string firstName, string lastName, 
            string email, string phoneNumber, string passwordHash,
            ApplicationUserRole role, RefreshToken refreshToken) 
            : base(firstName, lastName, email, phoneNumber, passwordHash, 
                  role, refreshToken)
        {
        }

        public static Admin Create(string firstName, string lastName,
            string email, string phoneNumber, string passwordHash,
            int accessFailedCount, bool isLocked, bool isActive,
            ApplicationUserRole role, RefreshToken refreshToken)
        {
            return new Admin(firstName, lastName, email, phoneNumber,
                passwordHash, accessFailedCount, isLocked, isActive, role, refreshToken);
        }
    }
}
