using System.Collections.Generic;
using System.Threading.Tasks;
using InternetBank.Data;
using InternetBank.Models;

namespace InternetBank.Repository
{
    public interface IAccountRepository
    {
        Task<AccountDetailsDto> AddAccount(CreateAccountDto createAccountDto, int userId);
        Task<bool> ChangePassword(ChangePasswordDto model, int userId);
        Task<BalanceDetailsDto> GetAccountBalance(int accountId, int userId);
        Task<bool> BlockAccount(int id, int userId);
        Task<bool> UnBlockAccount(int id, int userId);
        Task<List<AccountDto>> GetAllAccounts(int userId);
        Task<AccountDetailsDto> GetAccountById(int id, int userId);
    }
}