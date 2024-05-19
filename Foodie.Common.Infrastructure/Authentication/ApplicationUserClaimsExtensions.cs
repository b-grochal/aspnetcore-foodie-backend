using Foodie.Common.Enums;
using System;
using System.Security.Claims;

namespace Foodie.Common.Infrastructure.Authentication
{
    internal static class ApplicationUserClaimsExtensions
    {
        public static ApplicationUserRole GetRole(this ClaimsPrincipal? principal)
        {
            string role = principal?.FindFirstValue(ApplicationUserClaim.Role);

            return Enum.TryParse<ApplicationUserRole>(role, out var parsedRole) ? 
                parsedRole : 
                throw new InvalidOperationException("Role of application user is unavailable.");
        }

        public static int GetId(this ClaimsPrincipal? principal)
        {
            string id = principal?.FindFirstValue(ApplicationUserClaim.Id);

            return int.TryParse(id, out var parsedId) ?
                parsedId :
                throw new InvalidOperationException("Id of application user is unavailable.");
        }

        public static string GetEmail(this ClaimsPrincipal? principal)
        {
            var email = principal?.FindFirstValue(ApplicationUserClaim.Email);
            return email ?? throw new InvalidOperationException("Email of application user is unavailable.");
        }

        public static int GetLocationId(this ClaimsPrincipal? principal)
        {
            string locationId = principal?.FindFirstValue(ApplicationUserClaim.LocationId);

            return int.TryParse(locationId, out var parsedLocationId) ? 
                parsedLocationId :
                throw new InvalidOperationException("Location id of application user is unavailable.");
        }
    }
}
