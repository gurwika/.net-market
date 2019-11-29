using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Context.Abstraction;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Common.Application.Common.Handlers
{
    public abstract class DomainEventHandler
    {
        protected readonly IApplicationEventStore _applicationEventStore;
        protected readonly IApplicationDbContext _context;

        public DomainEventHandler(IApplicationDbContext context, IApplicationEventStore applicationEventStore)
        {
            _applicationEventStore = applicationEventStore;
            _context = context;
        }

        protected async Task SaveAndPublish(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
