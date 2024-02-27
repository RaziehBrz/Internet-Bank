using System.ComponentModel.DataAnnotations;

namespace InternetBank.Models
{

    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "لطفا آیدی حساب موردنظر را وارد کنید!")]
        public int AccountId { get; set; }
        [Required(ErrorMessage = "لطفا رمز ثابت قبلی حساب را وارد کنید!")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "لطفا رمز جدید قبلی حساب را وارد کنید!")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "لطفا تکرار رمز جدید حساب را وارد کنید!"), Compare(nameof(NewPassword))]
        public string RepeateNewPassword { get; set; }
    }

}