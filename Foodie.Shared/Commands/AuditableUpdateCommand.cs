using System.Text.Json.Serialization;

namespace Foodie.Shared.Commands
{
    public abstract class AuditableUpdateCommand
    {
        [JsonIgnore]
        public string LastModifiedBy { get; set; }
    }
}
