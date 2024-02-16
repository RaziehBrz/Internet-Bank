using System;
using System.Security.Claims;
using System.Threading.Tasks;
using InternetBank.Data;
using InternetBank.Models;
using InternetBank.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace InternetBank.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IRandomNumberService _randomNumberService;
        public AccountRepository(
            UserManager<ApplicationUser> userManager,
            IRandomNumberService randomNumberService)
        {
            _userManager = userManager;
            _randomNumberService = randomNumberService;
        }
        //Create new Account
        public async Task<int> AddAccount(CreateAccountDto createAccountDto)
        {
            var user = await _userManager.GetUserAsync(User);
            var account = new Account()
            {
                Type = createAccountDto.Type,
                Amount = createAccountDto.Amount,
            };

            account.Number = _randomNumberService.GenerateAccountNumber(account.Type, userId);
        }

    }


}