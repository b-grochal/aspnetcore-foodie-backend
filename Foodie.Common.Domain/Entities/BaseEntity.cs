using System;

namespace Foodie.Common.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTimeOffset? LastModifiedDate { get; set; }
    }
}
