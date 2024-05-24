using System;

namespace Foodie.Common.Infrastructure.Database.Audits
{
    public class Audit
    {
        public int Id { get; set; }

        public AuditType Type { get; set; }

        public DateTimeOffset ModificationDate {  get; set; }

        public string ModifiedBy { get; set; }

        public string TableName { get; set; }

        public string OldValues { get; set; }

        public string NewValues { get; set; }

        public string ModifiedColumns { get; set; }

        public string PrimaryKey {  get; set; }
    }
}
