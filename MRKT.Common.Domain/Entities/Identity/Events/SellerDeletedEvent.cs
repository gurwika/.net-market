using MRKT.Common.Domain.Common.Abstraction.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MRKT.Common.Domain.Entities.Identity.Events
{
    public class SellerDeletedEvent : IEvent
    {
        public Guid Id { get; }

        public SellerDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
