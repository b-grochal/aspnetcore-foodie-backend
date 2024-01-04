using Foodie.Common.Domain.AggregateRoots;
using System;

namespace Foodie.Orders.Domain.Buyers
{
    public class Buyer : AggregateRoot
    {
        public string CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }

        public Buyer(string customerId, string firstName, string lastName, string phoneNumber, string email)
        {
            CustomerId = !string.IsNullOrWhiteSpace(customerId) ? customerId : throw new ArgumentNullException(nameof(customerId));
            FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ArgumentNullException(nameof(firstName));
            LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName : throw new ArgumentNullException(nameof(lastName));
            PhoneNumber = !string.IsNullOrWhiteSpace(phoneNumber) ? phoneNumber : throw new ArgumentNullException(nameof(phoneNumber));
            Email = !string.IsNullOrWhiteSpace(email) ? email : throw new ArgumentNullException(nameof(email));
        }
    }
}
