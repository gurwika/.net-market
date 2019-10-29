using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class SellerSuspendedEvent : IEvent
    {
        public Guid Id { get; }

        public SellerSuspendedEvent(Guid id)
        {
            Id = id;
        }
    }
}
