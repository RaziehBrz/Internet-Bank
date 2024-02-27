using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace InternetBank.Validations
{
    public class IsValidCardNumberAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string cardNumber)
            {
                if (cardNumber.All(x => Char.IsDigit(x))
                                  && cardNumber.Length == 16)
                {
                    return true;
                }
            }
            return false;
        }
        public override string FormatErrorMessage(string name)
        {
            return "شماره کارت وارد شده باید 16 رقمی باشد!";
        }
    }
}