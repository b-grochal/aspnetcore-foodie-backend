using Ardalis.SmartEnum;

namespace Foodie.Shared.Authentication
{
    public class ApplicationUserClaims : SmartEnum<ApplicationUserClaims, string>
    {
        public static readonly ApplicationUserClaims ApplicationUserId = new ApplicationUserClaims(nameof(ApplicationUserId), "ApplicationUserId");
        public static readonly ApplicationUserClaims Email = new ApplicationUserClaims(nameof(Email), "Email");
        public static readonly ApplicationUserClaims Role = new ApplicationUserClaims(nameof(Role), "Role");
        public static readonly ApplicationUserClaims LocationId = new ApplicationUserClaims(nameof(LocationId), "LocationId");

        public ApplicationUserClaims(string name, string value) : base(name, value)
        {
        }
    }
}
