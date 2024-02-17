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
                var responseDto = new
                {
                    result.Number,
                    result.CardNumber,
                    result.Cvv2,
                    result.ExpireDate,
                    result.StaticPassword,
                    result.Id,
                    result.Type
                };
                return Ok(responseDto);
            }
            return Unauthorized();
        }
        [Authorize]
        [HttpPut("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {

        }
    }
}