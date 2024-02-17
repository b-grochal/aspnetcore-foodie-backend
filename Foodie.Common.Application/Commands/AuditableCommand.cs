using System.Text.Json.Serialization;

namespace Foodie.Common.Application.Commands
{
    public abstract class AuditableCommand
    {
        [JsonIgnore]
        public string User { get; set; }
    }
}
