using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Production.Events
{
    public class ProductUnPublishedEvent : IEvent
    {
        public Guid Id { get; protected set; }

        public ProductUnPublishedEvent(Guid id)
        {
            Id = id;
        }
    }
}
