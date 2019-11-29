using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class CustomerDeletedEvent : IEvent
    {
        public Guid Id { get; }
        public string Payload { get; protected set; }

        public CustomerDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
