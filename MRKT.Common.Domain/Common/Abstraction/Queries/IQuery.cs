using MediatR;

namespace MRKT.Common.Domain.Common.Abstraction.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
