using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Context.Abstraction;
using MRKT.Common.Domain.Common.Concrete.Aggregates;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Common.Application.Common.Handlers
{
    public abstract class CommandHandler
    {
        protected readonly IEventBus _eventBus;
        protected readonly IApplicationDbContext _context;

        public CommandHandler(IApplicationDbContext context, IEventBus eventBus)
        {
            _context = context;
            _eventBus = eventBus;
        }

        protected async Task SaveAndPublish(EventSourcedAggregate eventSourcedAggregate, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _context.SaveChangesAsync(cancellationToken);

            await _eventBus.Publish(eventSourcedAggregate.PendingEvents.ToArray());
        }
    }
}
