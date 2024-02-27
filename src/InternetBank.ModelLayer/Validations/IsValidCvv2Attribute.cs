using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace InternetBank.Validations
{
    public class IsValidCvv2Attribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string cvv2)
            {
                if (cvv2.All(x => Char.IsDigit(x))
                            && cvv2.Length == 4)
                {
                    return true;
                }
            }
            return false;
        }
        public override string FormatErrorMessage(string name)
        {
            return "cvv2 باید 4 رقمی باشد";
        }
    }
}