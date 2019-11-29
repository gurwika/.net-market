using MRKT.Common.Domain.Common.Abstraction.Events;

namespace MRKT.Common.Application.Common.Abstraction
{
    public interface IApplicationEventStore
    {
        public void Store<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
