using System.ComponentModel.DataAnnotations;

namespace InternetBank.Models
{
    public class LoginDto
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید!"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا رمزعبور را وارد کنید!")]
        public string Password { get; set; }
    }
}