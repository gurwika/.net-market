using MRKT.Common.Domain.Common.Abstraction.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRKT.Common.Domain.Entities.Production.Events
{
    public class StockQuantityUpdatedEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Payload { get; protected set; }

        public StockQuantityUpdatedEvent(
            Guid id,
            string payload
        )
        {
            Id = id;
            Payload = payload;
        }
    }
}
