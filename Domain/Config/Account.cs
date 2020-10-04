using System;

namespace Domain.Config
{
    public class Account
    {
        public string id { get; set; }
        public Guid apiKey { get; set; }
        public string companyName { get; set; }  
    }
}
