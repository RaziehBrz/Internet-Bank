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
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(
         IAccountRepository accountRepository,
         UserManager<ApplicationUser> userManager)
        {
            _accountRepository = accountRepository;
            _userManager = userManager;

        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] CreateAccountDto createAccountDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var userId = user.Id;
                var result = await _accountRepository.AddAccount(createAccountDto, userId);
                return Ok(result);
            }
            return Unauthorized();
        }
    }
}