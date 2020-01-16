using MRKT.Common.Domain.Common.Abstraction.Events;

namespace MRKT.Common.Application.Common.Abstraction
{
    public interface IStoredEventSerializer
    {
        IEvent As(string type, byte[] data);
        IEvent As(string type, string objectJson);
    }
}
