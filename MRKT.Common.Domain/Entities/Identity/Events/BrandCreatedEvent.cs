using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Selles.Events
{
    public class BrandCreatedEvent: IEvent
    {
        public Guid Id { get; protected set; }
        public string Data { get; protected set; }

        public BrandCreatedEvent(
            Guid id,
            string data
        )
        {
            Id = id;
            Data = data;
        }
    }
}
