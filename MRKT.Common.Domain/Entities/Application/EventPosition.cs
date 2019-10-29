using MRKT.Common.Domain.Common.Concrete.Aggregates;
using MRKT.Common.Domain.Enumarations.Application;
using System;

namespace MRKT.Common.Domain.Entities.Application
{
    public class EventPosition : Aggregate
    {
        public EventPosition()
        {
            CreatedAt = DateTime.Now;
        }

        public EventSubscriberType Type { get; protected set; }
        public long CommitPosition { get; protected set; }
        public long PreparePosition { get; protected set; }

        public EventPosition(long commitPosition, long preparePosition)
        {
            CommitPosition = commitPosition;
            PreparePosition = preparePosition;
            CreatedAt = DateTime.Now;
        }

        public void Update(long commitPosition, long preparePosition)
        {
            CommitPosition = commitPosition;
            PreparePosition = preparePosition;
            LastModified = DateTime.Now;
        }
    }
}
