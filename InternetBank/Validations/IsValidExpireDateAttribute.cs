using System;
using System.ComponentModel.DataAnnotations;

namespace InternetBank.Validations
{
    public class IsValidExpireDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string expireDate)
            {
                DateTime result;
                DateTime.TryParse(expireDate, out result);
                if (result <= DateTime.Now) return true;
            }
            return false;
        }
        public override string FormatErrorMessage(string name)
        {
            return "کارت وارد شده منقضی شده است";
        }
    }
}