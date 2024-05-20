using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace Foodie.Common.Infrastructure.Database.Audits
{
    public class AuditEntry
    {
        public EntityEntry Entity { get; }

        public int? ApplicationUserId { get; set; }

        public string ApplicationUserEmail { get; set; }

        public AuditType Type { get; set; }

        public Dictionary<string, object> TableName { get; set; }

        public Dictionary<string, object> OldValues { get; set; }

        public Dictionary<string, object> NewValues { get; set; }

        public List<string> ModifiedColumns { get; set; }

        public string PrimaryKey { get; set; }
    }
}
