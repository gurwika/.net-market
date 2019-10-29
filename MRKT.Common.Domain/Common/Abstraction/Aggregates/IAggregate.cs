using System;

namespace MRKT.Common.Domain.Common.Abstraction.Aggregates
{
    public interface IAggregate
    {
        Guid Id { get; }
        public DateTime CreatedAt { get; }
        public DateTime? LastModified { get; }
        public DateTime? DeletedAt { get; }
    }
}
