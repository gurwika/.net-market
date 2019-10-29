using MRKT.Common.Domain.Common.Abstraction.Aggregates;
using System;
using System.Text.Json.Serialization;

namespace MRKT.Common.Domain.Common.Concrete.Aggregates
{
    public abstract class Aggregate : IAggregate
    {
        [JsonIgnore]
        public Guid Id { get; protected set; }
        [JsonIgnore]
        public DateTime CreatedAt { get; protected set; }
        [JsonIgnore]
        public DateTime? LastModified { get; protected set; }
        [JsonIgnore]
        public DateTime? DeletedAt { get; protected set; }

        protected Aggregate()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
