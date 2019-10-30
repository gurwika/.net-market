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
        public string LastModifiedBy { get; protected set; }
        [JsonIgnore]
        public DateTime? LastModified { get; protected set; }
        [JsonIgnore]
        public DateTime? DeletedAt { get; protected set; }

        protected Aggregate()
        {
            CreatedAt = DateTime.Now;
        }

        public void UpdateAddedCredentials(DateTime createdAt, string lastModifiedBy)
        {
            CreatedAt = createdAt;
            LastModifiedBy = lastModifiedBy;
        }

        public void UpdateModifiedCredentials(DateTime lastModified, string lastModifiedBy)
        {
            LastModified = lastModified;
            LastModifiedBy = lastModifiedBy;
        }
    }
}
