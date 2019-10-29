using MRKT.Common.Domain.Common.Abstraction.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRKT.Common.Domain.Entities.Production.Events
{
    public class StockQuantityUpdatedEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Data { get; protected set; }

        public StockQuantityUpdatedEvent(
            Guid id,
            string data
        )
        {
            Id = id;
            Data = data;
        }
    }
}
