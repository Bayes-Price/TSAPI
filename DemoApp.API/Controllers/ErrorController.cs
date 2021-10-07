using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.API.Controllers
{
	/// <ignore/>
	[ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        /// <ignore/>
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            // TODO Log the global error here and invent the correct generic friendly problem details.
            Trace.WriteLine(context.Error.ToString());
            return Problem(statusCode: StatusCodes.Status500InternalServerError, title: "Web Service Request Failed", type: context.Error.GetType().Name, detail: context.Error.Message);
        }
    }
}