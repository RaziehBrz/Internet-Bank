using System;

namespace InternetBank.Models
{
    public class AccountDetailsDto
    {
        public string Number { get; set; }
        public string CardNumber { get; set; }
        public string Cvv2 { get; set; }
        public string ExpireDate { get; set; }
        public string StaticPassword { get; set; }
        public int Id { get; set; }
        public int Type { get; set; }
    }
}