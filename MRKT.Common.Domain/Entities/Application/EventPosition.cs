using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Enumarations.Application;
using System;

namespace MRKT.Common.Domain.Entities.Application
{
    public class EventPosition : Aggregate
    {
        public EventPosition()
        {
        }

        public EventSubscriberType Type { get; protected set; }
        public long CommitPosition { get; protected set; }
        public long PreparePosition { get; protected set; }

        public EventPosition(EventSubscriberType type, long commitPosition, long preparePosition)
        {
            Type = type;
            CommitPosition = commitPosition;
            PreparePosition = preparePosition;
        }

        public void Update(long commitPosition, long preparePosition)
        {
            CommitPosition = commitPosition;
            PreparePosition = preparePosition;
        }
    }
}
