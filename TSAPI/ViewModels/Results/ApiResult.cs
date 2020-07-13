namespace TSAPI.ViewModels
{
    public abstract class ApiResult
    {
        public int StatusCode { get; set; } = 200; 
        public string Message { get; set; } = "OK";
    }
}