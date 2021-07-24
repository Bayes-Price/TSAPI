using Domain;

namespace Logic.Command.Common
{
    public abstract class CommandResult
    {
        #region "Properties"
        protected CommandResult(Enums.ResultCode result, string message)
        {
            Result = result;
            Message = message;
        }
        protected CommandResult()
        {
            Result = Enums.ResultCode.Ok;
            Message = "";
        }
        protected CommandResult(CommandResult source)
        {
            Result = source.Result;
            Message = source.Message;
        }

        public Enums.ResultCode Result { get; set; }
        public string Message { get; set; }
        #endregion
    }
}
