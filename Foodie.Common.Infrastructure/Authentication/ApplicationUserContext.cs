using Foodie.Common.Application.Contracts.Infrastructure.Authentication;
using Foodie.Common.Enums;
using Microsoft.AspNetCore.Http;
using System;

namespace Foodie.Common.Infrastructure.Authentication
{
    public class ApplicationUserContext : IApplicationUserContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationUserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ApplicationUserRole Role =>
            _httpContextAccessor
            .HttpContext?
            .User
            .GetRole() ??
        throw new InvalidOperationException("Role of application user is unavailable.");

        public int LocationId =>
            _httpContextAccessor
            .HttpContext?
            .User
            .GetLocationId() ??
        throw new InvalidOperationException("Location id of application user is unavailable.");

        public string Email =>
            _httpContextAccessor
            .HttpContext?
            .User
            .GetEmail() ??
        throw new InvalidOperationException("Email of application user is unavailable.");

        public int Id =>
            _httpContextAccessor
            .HttpContext?
            .User
            .GetId() ??
        throw new InvalidOperationException("Id of application user is unavailable.");
    }
}
