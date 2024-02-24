using System.Threading.Tasks;
using InternetBank.Models;

namespace InternetBank.Repository
{
    public interface ITransactionRepository
    {
        Task<int> SendOtp(SendOtpDto model, int userId);
        Task<bool> TransferMoney(TransferMoneyDto model, int UserId);

    }
}