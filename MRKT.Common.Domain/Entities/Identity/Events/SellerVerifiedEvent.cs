using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    class SellerVerifiedEvent : IEvent
    {
        public Guid Id { get; }
        public string Payload { get; protected set; }

        public SellerVerifiedEvent(Guid id)
        {
            Id = id;
        }
    }
}
