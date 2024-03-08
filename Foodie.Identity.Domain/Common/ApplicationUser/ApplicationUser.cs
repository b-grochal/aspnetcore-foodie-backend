using Foodie.Common.Domain.Entities;
using Foodie.Common.Enums;

namespace Foodie.Identity.Domain.Entities
{
    public class ApplicationUser : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public int AccessFailedCount { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }
        public ApplicationUserRole Role { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
