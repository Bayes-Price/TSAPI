using System.Threading.Tasks;

namespace Logic.Command.Common
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        CommandResult Handle(TCommand command);
        Task<CommandResult> HandleAsync(TCommand command);
    }
}
