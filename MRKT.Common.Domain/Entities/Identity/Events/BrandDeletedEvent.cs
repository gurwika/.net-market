using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class BrandDeletedEvent : IEvent
    {
        public Guid Id { get; protected set; }

        public string Payload { get; protected set; }

        public BrandDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
