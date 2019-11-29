using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Payments.Events
{
    public class OrderDetailCreatedEevent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Payload { get; protected set; }

        public OrderDetailCreatedEevent(
            Guid id,
            string payload
        )
        {
            Id = id;
            Payload = payload;
        }
    }
}
