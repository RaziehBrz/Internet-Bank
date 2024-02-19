using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using InternetBank.Data;
using InternetBank.Models;
using InternetBank.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

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
        public async Task<AccountDetailsDto> AddAccount(CreateAccountDto createAccountDto, int userId)
        {
            var account = new Account()
            {
                Type = createAccountDto.Type,
                Amount = createAccountDto.Amount,
                CardNumber = _randomService.CardNumberGenerator(),
                Cvv2 = _randomService.Cvv2Generator(),
                ExpireDate = DateTime.Now.AddYears(5).ToString("yy/MM"),
                StaticPassword = _randomService.PasswordGenerator(),
                CreatedOn = DateTime.Now,
                UserId = userId
            };
            account.Number = _randomService.AccountNumberGenerator(account.Type, userId);

            _context.Account.Add(account);
            await _context.SaveChangesAsync();

            return new AccountDetailsDto()
            {
                Number = account.Number,
                CardNumber = account.CardNumber,
                Cvv2 = account.Cvv2,
                ExpireDate = account.ExpireDate,
                StaticPassword = account.StaticPassword,
                Id = account.Id,
                Type = account.Type
            };
        }

        //Change Account static password
        public async Task<bool> ChangePassword(ChangePasswordDto model)
        {
            var account = await _context.Account.Where(x => x.Id == model.AccountId).FirstOrDefaultAsync();
            if (account is null) return false;

            account.StaticPassword = model.NewPassword;
            account.ModifiedOn = DateTime.Now;
            await _context.SaveChangesAsync();
            return true;
        }

        //Get account balance
        public async Task<BalanceDetailsDto> GetAccountBalance(int accountId)
        {
            var account = await _context.Account.Where(x => x.Id == accountId).Select(x => new BalanceDetailsDto()
            {
                Amount = x.Amount,
                AccountId = x.Id,
                AccountNumber = x.Number
            }).FirstOrDefaultAsync();

            return account;
        }
        //Block account
        public async Task<bool> BlockAccount(int id)
        {
            var account = await _context.Account.Where(x => x.Id == id)
                                                .FirstOrDefaultAsync();
            if (account is null) return false;

            account.IsBlocked = true;
            await _context.SaveChangesAsync();
            return true;
        }
        //Unblock account
        public async Task<bool> UnBlockAccount(int id)
        {
            var account = await _context.Account.Where(x => x.Id == id)
                                                .FirstOrDefaultAsync();
            if (account is null) return false;

            account.IsBlocked = false;
            await _context.SaveChangesAsync();
            return true;
        }
        //Get all accounts
        public async Task<List<AccountDto>> GetAllAccounts(int userId)
        {
            var accounts = await _context.Account.Where(x => x.UserId == userId).Select(x =>
            new AccountDto()
            {
                Number = x.Number,
                Id = x.Id,
                CardNumber = x.CardNumber
            }).ToListAsync();

            return accounts;
        }
    }
}