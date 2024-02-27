using System.Security.Claims;
using System.Threading.Tasks;
using InternetBank.Data;
using InternetBank.Models;
using InternetBank.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InternetBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public partial class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        public int UserId
        {
            get
            {
                return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
        }
        public AccountController(
         IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] CreateAccountDto model)
        {
            if (UserId != 0)
            {
                var result = await _accountRepository.AddAccount(model, UserId);
                return Ok(result);
            }

            return Unauthorized();
        }
        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            var result = await _accountRepository.ChangePassword(model, UserId);
            if (result) return Ok("رمز ثابت حساب با موفقیت تغییر کرد!");
            return BadRequest();
        }
        [Authorize]
        [HttpGet("balance/{account_id}")]
        public async Task<IActionResult> GetAccountBalance(int account_id)
        {
            var result = await _accountRepository.GetAccountBalance(account_id, UserId);
            if (result is null) return BadRequest();
            return Ok(result);
        }
        [Authorize]
        [HttpPut("block/{account_id}")]
        public async Task<IActionResult> BlockAccount(int account_id)
        {
            var result = await _accountRepository.BlockAccount(account_id, UserId);
            if (!result) return BadRequest();
            return Ok();
        }
        [Authorize]
        [HttpPut("unblock/{account_id}")]
        public async Task<IActionResult> UnBlockAccount(int account_id)
        {
            var result = await _accountRepository.UnBlockAccount(account_id, UserId);
            if (!result) return BadRequest();
            return Ok();
        }
        //Get all accounts
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var result = await _accountRepository.GetAllAccounts(UserId);
            return Ok(result);
        }
        //Get an account by id
        [Authorize]
        [HttpGet("{account_id}")]
        public async Task<IActionResult> GetAccountById(int account_id)
        {
            var result = await _accountRepository.GetAccountById(account_id, UserId);
            return Ok(result);
        }
    }
}
