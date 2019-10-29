using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class BrandUpdatedEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Data { get; protected set; }

        public BrandUpdatedEvent(
            Guid id,
            string data
        )
        {
            Id = id;
            Data = data;
        }
    }
}
