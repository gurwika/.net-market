using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class CustomerCreatedEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Data { get; protected set; }

        public CustomerCreatedEvent(
            Guid id,
            string data
        )
        {
            Id = id;
            Data = data;
        }
    }
}
