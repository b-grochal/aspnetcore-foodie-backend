using System.Text.Json.Serialization;

namespace Foodie.Shared.Commands
{
    public abstract class AuditableCreateCommand
    {
        [JsonIgnore]
        public string CreatedBy { get; set; }
    }
}
