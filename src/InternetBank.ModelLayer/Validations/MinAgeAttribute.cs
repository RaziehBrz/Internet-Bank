using System;
using System.ComponentModel.DataAnnotations;

namespace InternetBank.Validations
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;
        public MinAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }
        public override bool IsValid(object value)
        {
            if (value is DateTime birthDate)
            {
                if (birthDate.AddDays(_minimumAge) > DateTime.Now) return false;
            }
            return true;
        }
        public override string FormatErrorMessage(string name)
        {
            return $"سن شما باید حداقل {_minimumAge}سال باشد!";
        }
    }


}