using Ardalis.SmartEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Enums
{
    public class ApplicationUserClaims : SmartEnum<ApplicationUserClaims, string>
    {
        public static readonly ApplicationUserClaims Role = new ApplicationUserClaims(nameof(Role), "Role");
        public static readonly ApplicationUserClaims LocationId = new ApplicationUserClaims(nameof(LocationId), "LocationId");
        
        public ApplicationUserClaims(string name, string value) : base(name, value)
        {
        }
    }
}
