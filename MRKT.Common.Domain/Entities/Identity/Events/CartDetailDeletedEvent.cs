using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class CartDetailDeletedEvent : IEvent
    {
        public Guid Id { get; }
        public string Payload { get; protected set; }

        public CartDetailDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
