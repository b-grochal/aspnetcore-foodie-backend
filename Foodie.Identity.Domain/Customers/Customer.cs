using Foodie.Common.Enums;
using Foodie.Identity.Domain.Common.ApplicationUser;
using Foodie.Identity.Domain.Common.ApplicationUser.ValueObjects;

namespace Foodie.Identity.Domain.Customers
{
    public class Customer : ApplicationUser
    {
        public Customer(string firstName, string lastName,
            string email, string phoneNumber, string passwordHash,
            RefreshToken refreshToken)
            : base(firstName, lastName, email, phoneNumber, passwordHash,
                  ApplicationUserRole.Customer, refreshToken)
        {
        }

        public static Customer Create(string firstName, string lastName,
            string email, string phoneNumber, string passwordHash)
        {
            return new Customer(firstName, lastName, email, phoneNumber, 
                passwordHash, RefreshToken.CreateEmpty());
        }
    }
}
