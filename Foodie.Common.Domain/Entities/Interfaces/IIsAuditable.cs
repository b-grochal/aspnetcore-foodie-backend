using System;

namespace Foodie.Common.Domain.Entities.Interfaces
{
    public interface IIsAuditable
    {
        string CreatedBy { get; }

        DateTimeOffset CreatedDate { get; }

        string LastModifiedBy { get; }

        DateTimeOffset? LastModifiedDate { get; }
    }
}
