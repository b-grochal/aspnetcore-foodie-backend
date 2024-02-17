using System;

namespace Foodie.Common.Domain.Entities.Interfaces
{
    public interface IIsAuditable
    {
        string CreatedBy { get; set; }

        DateTimeOffset CreatedDate { get; set; }

        string LastModifiedBy { get; set; }

        DateTimeOffset? LastModifiedDate { get; set; }
    }
}
