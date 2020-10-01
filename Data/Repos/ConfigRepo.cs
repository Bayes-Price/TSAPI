using System;
using System.Collections.Generic;
using System.Text;
using Data.Common.Repos;

namespace Data.Repos
{
    public class ConfigRepo : IConfigRepo
    {
        public string CreateAccount(string companyName)
        {
            var client = new Microsoft.Azure.Cosmos.CosmosClient("AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");

            var container = client.GetContainer("tsapidb", "tsapiconfig");
            var account = new Account { id  = companyName, companyname = companyName};

            var result = container.CreateItemAsync(account).Result;


            return result.StatusCode.ToString();
        }
    }


    public class Account
    {
        public string id { get; set; }
        public string companyname { get; set; }
    }

}
