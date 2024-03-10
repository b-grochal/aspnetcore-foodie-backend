using Foodie.Common.Enums;
using Foodie.Identity.Domain.Common.ApplicationUser;

namespace Foodie.Identity.Domain.Customers
{
    public class Customer : ApplicationUser
    {
        public Customer(string firstName, string lastName,
            string email, string phoneNumber, string passwordHash)
            : base(firstName, lastName, email, phoneNumber, passwordHash,
                  ApplicationUserRole.Customer)
        {
        }

        public static Customer Create(string firstName, string lastName,
            string email, string phoneNumber, string passwordHash)
        {
            return new Customer(firstName, lastName, email, phoneNumber,
                passwordHash);
        }
    }
}
