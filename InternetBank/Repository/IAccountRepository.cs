using System.Threading.Tasks;
using InternetBank.Data;
using InternetBank.Models;

namespace InternetBank.Repository
{
    public interface IAccountRepository
    {
        Task<AccountDetailsDto> AddAccount(CreateAccountDto createAccountDto, int userId);
        Task<bool> ChangePassword(ChangePasswordDto model);
        Task<BalanceDetailsDto> GetAccountBalance(int accountId);
        Task<bool> BlockAccount(int id);
        Task<bool> UnBlockAccount(int id);
    }
}