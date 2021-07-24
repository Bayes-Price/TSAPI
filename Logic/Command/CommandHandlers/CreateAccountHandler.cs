using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Logic.Command.Common;
using Logic.Commands.Config;

namespace Logic.Command.CommandHandlers
{
    public class CreateAccountHandler : ICommandHandler<CreateAccount>
    {
        public CommandResult Handle(CreateAccount command)
        {
            throw new NotImplementedException();
        }

        public Task<CommandResult> HandleAsync(CreateAccount command)
        {
            throw new NotImplementedException();
        }
    }
}
