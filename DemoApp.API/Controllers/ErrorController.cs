using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.API.Controllers
{
    /// <summary>
    /// A simple sample error handler.
    /// See: <a href="https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-5.0">Handle errors in ASP.NET Core web APIs</a>.
    /// </summary>
	[ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Trace.WriteLine(context.Error.ToString());
            return Problem(
                statusCode: StatusCodes.Status500InternalServerError,
                title: "Web Service Request Failed",
                type: context.Error.GetType().Name,
                detail: context.Error.Message
            );
        }
    }
}