using Foodie.Shared.Entities;
using Foodie.Shared.Enums;

namespace Foodie.Identity.Domain.Entities
{
    public class ApplicationUser : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsLocked { get; set; }
        public ApplicationUserRole Role { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
