using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InternetBank.Data;
using InternetBank.Models;
using InternetBank.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InternetBank.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbConext _context;
        private readonly IRandomService _randomService;
        public AccountRepository(
            ApplicationDbConext context,
            IRandomService randomService)
        {
            _context = context;
            _randomService = randomService;
        }
        //Create new Account
        public async Task<Account> AddAccount(CreateAccountDto createAccountDto, int userId)
        {
            var account = new Account()
            {
                Type = createAccountDto.Type,
                Amount = createAccountDto.Amount,
                CardNumber = _randomService.CardNumberGenerator(),
                Cvv2 = _randomService.Cvv2Generator(),
                ExpireDate = (DateTime.Now.Year + 5).ToString() + '/' + DateTime.Now.Month.ToString(),
                StaticPassword = _randomService.PasswordGenerator(),
                CreatedOn = DateTime.Now,
                UserId = userId
            };
            account.Number = _randomService.AccountNumberGenerator(account.Type, userId);

            _context.Account.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        //Change Account static password
        public async Task<bool> ChangePassword(ChangePasswordDto model)
        {
            var account = await _context.Account.Where(x => x.Id == model.AccountId).FirstOrDefaultAsync();
            if (account is null) return false;

            account.StaticPassword = model.NewPassword;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}