using MRKT.Common.Domain.Common.Abstraction.Events;
using System.Collections.Generic;

namespace MRKT.Common.Domain.Common.Abstraction.Aggregates
{
    public interface IEventSourcedAggregate : IAggregate
    {
        Queue<IEvent> PendingEvents { get; }
    }
}
