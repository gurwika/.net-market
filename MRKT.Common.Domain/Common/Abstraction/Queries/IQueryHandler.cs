using MediatR;

namespace MRKT.Common.Domain.Common.Abstraction.Queries
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
           where TQuery : IQuery<TResponse>
    { 
    }
}
