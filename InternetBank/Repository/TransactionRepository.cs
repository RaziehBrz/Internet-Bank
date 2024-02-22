using System;
using System.Linq;
using System.Threading.Tasks;
using DNTPersianUtils.Core;
using InternetBank.Data;
using InternetBank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InternetBank.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public TransactionRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<int> SendOtp(SendOtpDto model, int userId)
        {
            var account = await _context.Account.Where(x => x.UserId == userId
                                                     && x.CardNumber == model.SourceCardNumber
                                                     && x.Cvv2 == model.Cvv2
                                                     && x.ExpireDate == model.ExpireDate
                                                     && x.IsBlocked == false).FirstOrDefaultAsync();

            if (account is null) return 0;

            var user = await _context.User.Where(x => x.Id == account.UserId).FirstOrDefaultAsync();
            var dynamicPass = new Random().Next(10000, 1000000);
            var displayCardNumber = model.SourceCardNumber.Substring(0, 5) + "*******" + model.SourceCardNumber.Substring(11, 4);

            var message = $"مبلغ : {model.Amount} \nتاریخ : {DateTime.Now.ToShortPersianDateString()}\nساعت :{DateTime.Now.TimeOfDay}\nشماره کارت : {displayCardNumber}\nرمز پویا : {dynamicPass}";

            var sender = _configuration["Kavenegar:Sender"];
            var receptor = user.PhoneNumber;
            var api = new Kavenegar.KavenegarApi(_configuration["Kavenegar:ApiKey"]);
            api.Send(sender, receptor, message);

            var transaction = new Transaction()
            {
                AccountId = account.Id,
                DestinationCardNumber = model.DestinationCardNumber,
                Amount = model.Amount,
                Otp = dynamicPass
            };
            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();

            return transaction.Id;
        }

    }
}