using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using DNTPersianUtils.Core;
using InternetBank.Validations;

namespace InternetBank.Models
{
    public class SignUpDto
    {
        [Required(ErrorMessage = "لطفا نام خود را وارد کنید!"),
        ShouldContainOnlyPersianLetters(ErrorMessage = "لطفا نام خود را به زبان فارسی وارد کنید !")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "لطفا نام خانوداگی خود را وارد کنید!"),
        ShouldContainOnlyPersianLetters(ErrorMessage = "لطفا نام خانوداگی را به زبان فارسی وارد کنید!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "لطفا کدملی را وارد کنید!"),
        ValidIranianNationalCode(ErrorMessage = "لطفا کدملی را به صورت صحیح وارد کنید!")]
        public string NationalCode { get; set; }
        [Required(ErrorMessage = "لطفا تاریخ تولد خود را وارد کنید!"), MinAge(18)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "لطفا شماره موبایل خود را وارد کنید!"),
        ValidIranianMobileNumber(ErrorMessage = "لطفا شماره موبایل را به صورت صحیح وارد کنید!")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "لطفا ایمیل خود را وارد کنید!"),
         EmailAddress(ErrorMessage = "لطفا ایمیل خود را به صورت صحیح وارد کنید!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا رمزعبور انتخابی را وارد کنید!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا رمزعبور را مجددا وارد کنید!"),
        Compare(nameof(Password), ErrorMessage = "رمزعبور وارد شده با رمز عبور انتخابی مطابقت ندارد!")]
        public string ConfirmPassword { get; set; }
    }
}