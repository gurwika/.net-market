using System.Threading.Tasks;

namespace MRKT.Common.Domain.Common.Abstraction.Commands
{
    public interface ICommandBus
    {
        Task Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
