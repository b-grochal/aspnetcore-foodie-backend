using Foodie.Common.Domain.AggregateRoots;
using Foodie.Common.Enums;
using Foodie.Common.Results;
using Foodie.Identity.Domain.Common.ApplicationUser.DomainEvents;
using Foodie.Identity.Domain.Common.ApplicationUser.Errors;
using Foodie.Identity.Domain.Common.ApplicationUser.ValueObjects;
using System;

namespace Foodie.Identity.Domain.Common.ApplicationUser
{
    public abstract class ApplicationUser : AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
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

        public Result ChangeEmail(string email)
        {
            if (Email == email)
                return Result.Failure(ApplicationUserDomainErrors.SameEmailAsOldOne());

            Email = email;
            IsActive = false;

            AddDomainEvent(new ApplicationUserEmailChangedDomainEvent(email));

            return Result.Success();
        }

        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void Update(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public void Update(string firstName, string lastName, string phoneNumber, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;

            AddDomainEvent(new ApplicationUserEmailChangedDomainEvent(email));
        }
    }
}
