using MediatR;

namespace MRKT.Common.Domain.Common.Abstraction.Events
{
    public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
           where TEvent : IEvent
    {
    }
}
