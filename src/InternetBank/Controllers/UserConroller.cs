using System;
using System.Linq;
using System.Threading.Tasks;
using InternetBank.Models;
using InternetBank.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InternetBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] SignUpDto signUpDto)
        {
            var result = await _userRepository.SignUp(signUpDto);
            if (!result.Succeeded) return BadRequest(result.Errors.Select(x => x.Description));
            return Ok("ثبت نام شما با موفقیت انجام شد!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _userRepository.Login(loginDto);
            if (String.IsNullOrEmpty(result)) return Unauthorized("ورود ناموفق!");
            return Ok(result);
        }

    }
}