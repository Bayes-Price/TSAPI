using System.Threading.Tasks;

namespace Logic.Command.Common
{
    public interface ICommandDispatcher
    {
        //CommandResult Submit<T>(T command) where T : ICommand;
        Task<CommandResult> HandleAsync<T>(T command) where T : ICommand;
    }
}