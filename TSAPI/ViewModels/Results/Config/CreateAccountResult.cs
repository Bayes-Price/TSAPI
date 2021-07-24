namespace TSAPI.ViewModels.Results.Config
{
    public class CreateAccountResult : ApiResult
    {
        public string ApiKey { get; set; }
        public string Note => "Please make a note of this Api Key - you will need it to access all services in the API";
    }
}
