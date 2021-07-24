using System.Security;
using Microsoft.AspNetCore.Http;
using Domain;

namespace TSAPI.Controllers.ExtensionMethods
{
    public static class HttpExtensions
    {

        public static string GetApiKey(this HttpRequest request)
        {
            if (!request.Headers.ContainsKey(Consts.APiKeyHeaderName))
                throw new SecurityException("Autorisation header not found in request");
                
            return request.Headers[Consts.APiKeyHeaderName];
        }
    }
}
