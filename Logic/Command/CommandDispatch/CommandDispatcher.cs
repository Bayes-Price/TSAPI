using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logic.Command.Common;

namespace Logic.Command.CommandDispatch
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        //public CommandResult Submit<T>(T query) where T : ICommand
        //{
        //    var handler = _container.Resolve<ICommandHandler<T>>();

        //    if (handler == null)
        //        throw new Exception("Cannot find matching command handler for " + query);

        //    return handler.HandleQuery(query);

        //}

        public async Task<CommandResult> HandleAsync<T>(T command) where T : ICommand
        {
            var service = this._serviceProvider.GetService(typeof(ICommandHandler<T>)) as ICommandHandler<T>;
            if (service == null) 
                throw new ArgumentException($"Failed to find dispatcher for '{command.GetType().Name}'");
            return await service.HandleAsync(command);
        }
    }
}
