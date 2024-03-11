using Foodie.Common.Domain.AggregateRoots;
using Foodie.Common.Enums;
using Foodie.Identity.Domain.Common.ApplicationUser.DomainEvents;
using Foodie.Identity.Domain.Common.ApplicationUser.ValueObjects;
using System;

namespace Foodie.Identity.Domain.Common.ApplicationUser
{
    public abstract class ApplicationUser : AggregateRoot
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; private set; }
        public string PhoneNumber { get; }
        public string PasswordHash { get; private set; }
        public int AccessFailedCount { get; private set; }
        public bool IsLocked { get; private set; }
        public bool IsActive { get; private set; }
        public ApplicationUserRole Role { get; }
        public RefreshToken RefreshToken { get; private set; }

        protected ApplicationUser(string firstName, string lastName, string email,
            string phoneNumber, string passwordHash, ApplicationUserRole role, 
            RefreshToken refreshToken = null)
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

        public void NoteInvalidAuthentication()
        {
            AccessFailedCount++;

            // TODO: Get rid of magic numbers
            if (AccessFailedCount == 5)
                IsLocked = true;
        }

        public void UpdateRefreshToken(string token, DateTimeOffset expirationTime)
        {
            RefreshToken = RefreshToken.Create(token, expirationTime);
        }

        public void RevokeRefreshToken()
        {
            RefreshToken = null;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            IsActive = false;

            AddDomainEvent(new ApplicationUserEmailChangedDomainEvent(email));
        }
    }
}
