using System.Security.Claims;
using System.Threading.Tasks;
using InternetBank.Models;
using InternetBank.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternetBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        public int UserId
        {
            get
            {
                return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
        }
        public TransactionController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        [Authorize]
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpDto model)
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var result = await _transactionRepository.SendOtp(model, userId);
            if (result == 0) return BadRequest();
            return Ok(result);
        }
        [Authorize]
        [HttpPatch("transfer-money")]
        public async Task<IActionResult> TransferMoney(TransferMoneyDto model)
        {
            var result = await _transactionRepository.TransferMoney(model, UserId);
            if (!result) return BadRequest("انتقال پول ناموفق!");
            return Ok("انتقال پول با موفقیت انجام شد!");
        }
        [Authorize]
        [HttpGet("report")]
        public async Task<IActionResult> GetTransactions(string from, string to, bool isSuccess)
        {
            var result = await _transactionRepository.GetTransactions(from, to, isSuccess, UserId);
            return Ok(result);
        }
    }
}