using System.Threading.Tasks;
using Domain.Config;

namespace Data.Common.Repos
{
    interface IConfigRepo
    {
        Task<bool> AccountExists(string companyName);
        Task<Account> CreateAccount(string companyName);
    }
}
