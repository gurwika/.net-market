using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Production.Events
{
    public class StockDeletedEvent : IEvent
    {
        public Guid Id { get; protected set; }

        public StockDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
