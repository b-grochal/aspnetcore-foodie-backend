using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Commands
{
    public abstract class AuditableUpdateCommand
    {
        [IgnoreDataMember]
        public string LastModifiedBy { get; set; }
    }
}
