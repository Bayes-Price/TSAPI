using System;

namespace Domain.Config
{
    public class Account
    {
        public Guid Id { get; set; } 
        public string CompanyName {  get;  set; }
        public string ApiKey { get; set; }
    }
}
