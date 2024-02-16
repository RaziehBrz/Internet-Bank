using System.Threading.Tasks;
using InternetBank.Data;
using InternetBank.Models;

namespace InternetBank.Repository
{
    public interface IAccountRepository
    {
        Task<Account> AddAccount(CreateAccountDto createAccountDto, int userId);
    }
}