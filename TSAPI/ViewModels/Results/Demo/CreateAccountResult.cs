using System;

namespace TSAPI.ViewModels.Results.Demo
{
    public class CreateAccountResult : ApiResult
    {
        public Guid ApiKey { get; set; }
        public string Important => "Please make a note of your API Key and keep this safe. You will need it to access the API.";
    }
}
