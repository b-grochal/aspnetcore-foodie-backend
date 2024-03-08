using Foodie.Common.Enums;
using Foodie.Identity.Domain.Common.ApplicationUser;
using Foodie.Identity.Domain.Common.ApplicationUser.ValueObjects;

namespace Foodie.Identity.Domain.Customers
{
    public class Customer : ApplicationUser
    {
        public Customer(string firstName, string lastName,
            string email, string phoneNumber, string passwordHash,
            int accessFailedCount, bool isLocked, bool isActive,
            ApplicationUserRole role, RefreshToken refreshToken)
            : base(firstName, lastName, email, phoneNumber, passwordHash,
                  accessFailedCount, isLocked, isActive, role, refreshToken)
        {
        }

        public static Customer Create(string firstName, string lastName,
            string email, string phoneNumber, string passwordHash,
            int accessFailedCount, bool isLocked, bool isActive,
            ApplicationUserRole role, RefreshToken refreshToken)
        {
            return new Customer(firstName, lastName, email, phoneNumber, 
                passwordHash, accessFailedCount, isLocked, isActive, role, refreshToken);
        }
    }
}
