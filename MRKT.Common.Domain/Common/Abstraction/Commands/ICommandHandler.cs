using MediatR;

namespace MRKT.Common.Domain.Common.Abstraction.Commands
{
    public interface ICommandHandler<in T> : IRequestHandler<T>
        where T : ICommand
    {
    }
}
