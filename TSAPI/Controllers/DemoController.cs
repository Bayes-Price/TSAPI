using System.Threading.Tasks;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using TSAPI.ViewModels.Results.Demo;

namespace TSAPI.Controllers
{
    ///<summary>Contains methods for demo purposes - the methods are NOT part of the TSAPI spec</summary>
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        ///<summary>Creates an account in the Demo system</summary>
        [HttpGet]
        [Route("/CreateAccount/")]
        public async Task<CreateAccountResult> CreateAccount(string companyName)
        {
            var repo = new ConfigRepo();
            var result = await repo.CreateAccount(companyName);
            return new CreateAccountResult {ApiKey = result};
        }
    }
}