using Foodie.Common.Domain.AggregateRoots;
using System;

namespace Foodie.Orders.Domain.Buyers
{
    public class Buyer : AggregateRoot
    {
        public string CustomerId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public string Email { get; }

        private Buyer() { }

        private Buyer(string customerId, string firstName, string lastName, string phoneNumber, string email)
        {
            CustomerId = !string.IsNullOrWhiteSpace(customerId) ? customerId : throw new ArgumentNullException(nameof(customerId));
            FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName : throw new ArgumentNullException(nameof(lastName));
            PhoneNumber = !string.IsNullOrWhiteSpace(phoneNumber) ? phoneNumber : throw new ArgumentNullException(nameof(phoneNumber));
            Email = !string.IsNullOrWhiteSpace(email) ? email : throw new ArgumentNullException(nameof(email));
        }

        public static Buyer Create(string customerId, string firstName, string lastName, string phoneNumber, string email)
        {
            return new Buyer(customerId, firstName, lastName, phoneNumber, email);
        }
    }
}
