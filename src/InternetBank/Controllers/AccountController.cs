namespace InternetBank.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddAccount([FromBody] CreateAccountDto createAccountDto)
        {
            
        }


    }
}