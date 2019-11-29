using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class SellerSuspendedEvent : IEvent
    {
        public Guid Id { get; }
        public string Payload { get; protected set; }

        public SellerSuspendedEvent(Guid id)
        {
            Id = id;
        }
    }
}
