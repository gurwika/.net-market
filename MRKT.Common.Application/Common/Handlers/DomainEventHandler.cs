using MRKT.Common.Application.Context.Abstraction;
using System.Threading;
using System.Threading.Tasks;

namespace MRKT.Common.Application.Common.Handlers
{
    public abstract class DomainEventHandler
    {
        protected readonly IApplicationDbContext _context;

        public DomainEventHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected async Task SaveAndPublish(CancellationToken cancellationToken = default(CancellationToken))
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
