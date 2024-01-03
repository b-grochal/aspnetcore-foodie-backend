using Foodie.Common.Domain.Entities.Interfaces;
using System;

namespace Foodie.Common.Domain.Entities
{
    public abstract class AuditableEntity<TId> : BaseEntity<TId>, IIsAuditable
    {
        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
        
        public string LastModifiedBy { get; set; }
        
        public DateTimeOffset? LastModifiedDate { get; set; }
    }
}
