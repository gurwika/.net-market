using EventStore.ClientAPI;
using MRKT.Common.Application.Common.Abstraction;
using MRKT.Common.Application.Context.Abstraction;
using MRKT.Common.Domain.Entities.Application;
using MRKT.Common.Domain.Enumarations.Application;
using System.Linq;
using System.Threading.Tasks;

namespace MRKT.Common.Infrastructure.Services
{
    public class EventStorePositionService : IEventStorePositionService
    {
        private readonly IApplicationDbContext _context;

        public EventStorePositionService(
            IApplicationDbContext context
        )
        {
            _context = context;
        }

        private EventPosition LastPosition(EventSubscriberType eventSubscriberType)
        {
            return _context.Set<EventPosition>().FirstOrDefault(e => e.Type == eventSubscriberType);
        }

        public Position GetLastPosition(EventSubscriberType eventSubscriberType)
        {
            var lastPosition = LastPosition(eventSubscriberType);

            if (lastPosition == null)
                return Position.Start;

            return new Position(lastPosition.CommitPosition, lastPosition.PreparePosition);
        }

        public async Task StoreLastPosition(EventSubscriberType eventSubscriberType, long commit, long prepare)
        {
            var firstPosition = LastPosition(eventSubscriberType);

            if (firstPosition != null)
            {
                firstPosition.Update(commit, prepare);
            }
            else
            {
                _context.Add(new EventPosition(eventSubscriberType, commit, prepare));
            }

            await _context.SaveChangesAsync();
        }
    }
}
