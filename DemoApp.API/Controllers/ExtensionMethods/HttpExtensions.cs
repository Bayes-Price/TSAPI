using System.Security;
using Microsoft.AspNetCore.Http;

namespace DemoApp.API.Controllers.ExtensionMethods
{
    public static class HttpExtensions
    {

        //public static string GetApiKey(this HttpRequest request)
        //{
        //    if (!request.Headers.ContainsKey(Consts.APiKeyHeaderName))
        //        throw new SecurityException("Authorisation header not found in request");
                
        //    return request.Headers[Consts.APiKeyHeaderName];
        //}
    }
}
