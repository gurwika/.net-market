using MediatR;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Domain.Common.Abstraction.Events;
using System.Threading.Tasks;

namespace MRKT.Common.Infrastructure.Common
{
    public class EventBus : IEventBus
    {
        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish<TEvent>(params TEvent[] events) where TEvent : IEvent
        {
            foreach (var @event in events)
            {
                await _mediator.Publish(@event);
            }
        }
    }
}
