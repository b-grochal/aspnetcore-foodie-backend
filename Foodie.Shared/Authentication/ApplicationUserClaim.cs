using Ardalis.SmartEnum;

namespace Foodie.Shared.Authentication
{
    public class ApplicationUserClaim : SmartEnum<ApplicationUserClaim, string>
    {
        public static readonly ApplicationUserClaim ApplicationUserId = new ApplicationUserClaim(nameof(ApplicationUserId), "ApplicationUserId");
        public static readonly ApplicationUserClaim Email = new ApplicationUserClaim(nameof(Email), "Email");
        public static readonly ApplicationUserClaim Role = new ApplicationUserClaim(nameof(Role), "Role");
        public static readonly ApplicationUserClaim LocationId = new ApplicationUserClaim(nameof(LocationId), "LocationId");

        public ApplicationUserClaim(string name, string value) : base(name, value)
        {
        }
    }
}
