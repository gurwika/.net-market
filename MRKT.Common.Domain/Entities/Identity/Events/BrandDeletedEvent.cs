using MRKT.Common.Domain.Common.Abstraction.Events;
using System;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class BrandDeletedEvent : IEvent
    {
        public Guid Id { get; }

        public BrandDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
