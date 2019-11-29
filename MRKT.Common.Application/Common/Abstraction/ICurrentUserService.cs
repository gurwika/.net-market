using System.Net;

namespace MRKT.Common.Application.Common.Abstraction
{
    public interface ICurrentUserService
    {
        IPAddress Ip { get; }
        string UserId { get; }
        bool IsAuthenticated { get; }
    }
}
