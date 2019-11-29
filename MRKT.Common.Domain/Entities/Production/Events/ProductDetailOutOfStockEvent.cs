using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Production.Events
{
    public class ProductDetailOutOfStockEvent : IEvent
    {
        public Guid Id { get; protected set; }
        public string Payload { get; protected set; }

        public ProductDetailOutOfStockEvent(Guid id)
        {
            Id = id;
        }
    }
}
