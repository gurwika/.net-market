using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class BrandUpdatedEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Payload { get; }

        public BrandUpdatedEvent(
            Guid id,
            string payload
        )
        {
            Id = id;
            Payload = payload;
        }
    }
}
