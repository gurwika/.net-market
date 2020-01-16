using MRKT.Common.Domain.Enumarations.Application;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MRKT.Common.Application.Common.Abstraction
{
    public interface IApplicationEventSubscription
    {
        void Subscribe(EventSubscriberType eventSubscriberType, List<string> eventsToHandle);
    }
}
