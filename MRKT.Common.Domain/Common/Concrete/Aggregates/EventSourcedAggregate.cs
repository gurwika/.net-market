
using MRKT.Common.Domain.Common.Abstraction.Aggregates;
using MRKT.Common.Domain.Common.Abstraction.Events;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MRKT.Common.Domain.Common.Concrete.Aggregates
{
    public abstract class EventSourcedAggregate : Aggregate, IEventSourcedAggregate
    {
        [JsonIgnore]
        public Queue<IEvent> PendingEvents { get; private set; }

        protected EventSourcedAggregate()
        {
            PendingEvents = new Queue<IEvent>();
        }

        protected void RiseEvent(IEvent @event)
        {
            PendingEvents.Enqueue(@event);
        }
    }
}
