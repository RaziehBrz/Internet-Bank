using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace InternetBank.Data
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}