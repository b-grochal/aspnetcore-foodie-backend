using Foodie.Common.Domain.AggregateRoots;
using Foodie.Common.Enums;
using Foodie.Identity.Domain.Common.ApplicationUser.DomainEvents;
using Foodie.Identity.Domain.Common.ApplicationUser.ValueObjects;

namespace Foodie.Identity.Domain.Common.ApplicationUser
{
    public abstract class ApplicationUser : AggregateRoot
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string PasswordHash { get; }
        public int AccessFailedCount { get; }
        public bool IsLocked { get; }
        public bool IsActive { get; }
        public ApplicationUserRole Role { get; }
        public RefreshToken RefreshToken { get; }

        protected ApplicationUser(string firstName, string lastName, string email,
            string phoneNumber, string passwordHash, ApplicationUserRole role, 
            RefreshToken refreshToken)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            AccessFailedCount = 0;
            IsLocked = false;
            IsActive = false;
            Role = role;
            RefreshToken = refreshToken;

            AddDomainEvent(new ApplicationUserCreatedDomainEvent(email));
        }
    }
}
