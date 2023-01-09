using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Foodie.Shared.Commands
{
    public abstract class AuditableUpdateCommand
    {
        [JsonIgnore]
        public string LastModifiedBy { get; set; }
    }
}
