using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodie.Shared.Commands
{
    public abstract class AuditableCreateCommand
    {
        public string CreatedBy { get; set; }
    }
}
