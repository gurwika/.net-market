namespace MRKT.Common.Application.Common.Abstraction
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        bool IsAuthenticated { get; }
    }
}
