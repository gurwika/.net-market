using EventStore.ClientAPI;
using MRKT.Common.Domain.Enumarations.Application;
using System.Threading.Tasks;

namespace MRKT.Common.Application.Common.Abstraction
{
    public interface IEventStorePositionService
    {
        Position GetLastPosition(EventSubscriberType eventSubscriberType);
        Task StoreLastPosition(EventSubscriberType eventSubscriberType, long commit, long prepare);
    }
}
