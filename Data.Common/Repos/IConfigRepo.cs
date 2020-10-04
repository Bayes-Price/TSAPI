using System;
using System.Threading.Tasks;
using Domain.Config;

namespace Data.Common.Repos
{
    public interface IConfigRepo
    {
        Task<bool> AccountExists(string companyName);
        Task<Guid> CreateAccount(string companyName);
        Account GetAccount(Guid apiKey);
    }
}