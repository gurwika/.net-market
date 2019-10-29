using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class CustomerUpdatedEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Data { get; protected set; }

        public CustomerUpdatedEvent(
            Guid id,
            string data
        )
        {
            Id = id;
            Data = data;
        }
    }
}
