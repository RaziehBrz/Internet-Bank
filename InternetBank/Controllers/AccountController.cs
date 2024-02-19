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
        private readonly UserManager<ApplicationUser> _userManager;
        public int UserId
        {
            get
            {
                if (User != null)
                {
                    var user = _userManager.GetUserAsync(User);
                    return user.Id;
                }
                return 0;
            }
        }
        public AccountController(
         IAccountRepository accountRepository,
         UserManager<ApplicationUser> userManager)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] CreateAccountDto model)
        {
            var userId = UserId;
            if (UserId != 0)
            {
                var result = await _accountRepository.AddAccount(model, userId);
                return Ok(result);
            }
            return Unauthorized();
        }
        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            var result = await _accountRepository.ChangePassword(model);
            if (result) return Ok("رمز ثابت حساب با موفقیت تغییر کرد!");
            return BadRequest();
        }
        [Authorize]
        [HttpGet("balance/{account_id}")]
        public async Task<IActionResult> GetAccountBalance(int account_id)
        {
            var result = await _accountRepository.GetAccountBalance(account_id);
            if (result is null) return BadRequest();
            return Ok(result);
        }
        [Authorize]
        [HttpPut("block/{account_id}")]
        public async Task<IActionResult> BlockAccount(int account_id)
        {
            var result = await _accountRepository.BlockAccount(account_id);
            if (!result) return BadRequest();
            return Ok();
        }
        [Authorize]
        [HttpPut("unblock/{account_id}")]
        public async Task<IActionResult> UnBlockAccount(int account_id)
        {
            var result = await _accountRepository.UnBlockAccount(account_id);
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
    }
}
