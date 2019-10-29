using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Payments.Events
{
    public class OrderDeletedEvent: IEvent
    {
        public Guid Id { get; }

        public OrderDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
