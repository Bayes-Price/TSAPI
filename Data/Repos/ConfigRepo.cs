using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Data.Common.Repos;
using Domain.Config;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;

namespace Data.Repos
{
    public class ConfigRepo : IConfigRepo
    {

        #region "Public Methods"
        public async Task<bool> AccountExists(string companyName)
        {
            var container = GetContainer();
            var q = container.GetItemLinqQueryable<Account>();
            var iterator = q.Where(a => a.companyName == companyName).ToFeedIterator();
            var results = await iterator.ReadNextAsync();
            return results.Count != 0;
        }

        public async Task<Guid> CreateAccount(string companyName)
        {
            if (await AccountExists(companyName))
                throw new ArgumentException($"Account '{companyName}' already exists.");

            var apiKey = Guid.NewGuid();
            var account = new Account { id = apiKey.ToString(), companyName  = companyName, apiKey = apiKey };
            await GetContainer().CreateItemAsync(account);
            return apiKey;
        }

        public Account GetAccount(Guid apiKey)
        {
            var container = GetContainer();
            return container.GetItemLinqQueryable<Account>().Single(a => a.apiKey == apiKey);
        }

        #endregion

        #region "Private Methods"
        private Container GetContainer()
        {
            var client = new CosmosClient("AccountEndpoint=https://localhost:8081/;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==");
            return client.GetContainer("tsapidb", "tsapiconfig");
        }
        #endregion
    }

    
}
