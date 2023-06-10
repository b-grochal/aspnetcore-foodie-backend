using Foodie.Shared.Entities;
using System;

namespace Foodie.Identity.Domain.Entities
{
    public class ApplicationUserRefreshToken : AuditableEntity
    {
        public string Token { get; set; }
        public DateTimeOffset? ExpirationTime { get; set; }
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
