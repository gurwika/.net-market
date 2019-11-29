using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Payments.Events
{
    public class OrderDeletedEvent: IEvent
    {
        public Guid Id { get; }
        public string Payload { get; protected set; }

        public OrderDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
