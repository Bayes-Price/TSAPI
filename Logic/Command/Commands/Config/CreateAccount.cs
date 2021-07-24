using Logic.Command.Commands.Base;
using Logic.Command.Common;

namespace Logic.Commands.Config
{
    public class CreateAccount : BaseCommand, ICommand 
    {
        public string CompanyName { get; set; }
    }
}
