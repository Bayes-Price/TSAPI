using System.Threading.Tasks;
using Logic.Command.CommandResults;
using Logic.Command.Common;
using Logic.Commands.Config;
using Microsoft.AspNetCore.Mvc;
using TSAPI.Controllers.ExtensionMethods;
using TSAPI.ViewModels.Results.Config;

namespace TSAPI.Controllers
{
    /// <summary>Methods used only by this Demo application - these methods do not form part of the TSAPI standard</summary>
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {

        #region "Member Variables"
        private readonly ICommandDispatcher _commandDispatcher;
        //private readonly IQueryDispatcher _queryDispatcher;
        #endregion

        #region "Construction"
        /// <summary>Constructor for demo controller</summary>
        /// <param name="commandDispatcher"></param>
        public DemoController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }
        #endregion

        ///// <summary>Creates an account in this demo API</summary>
        ///// <param name="companyName"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("/Demo/")]
        //public async Task<CreateAccountResult> CreateAccount(string companyName)
        //{
        //    //TODO: Add in Automapper
        //    var command = new CreateAccount
        //    {
        //        //ApiKey = Request.GetApiKey(),
        //        CompanyName = companyName
        //    };

        //    var result = (CreateAccountCommandResult) await _commandDispatcher.HandleAsync(command);
        //    return new CreateAccountResult();
        //}


        //Delete Project
        //Populate with dummy data



    }
}
