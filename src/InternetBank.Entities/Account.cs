using System;
using System.Collections.Generic;

namespace InternetBank.Data
{
    public class Account : BaseEntity
    {
        public string Number { get; set; }
        public string CardNumber { get; set; }
        public string Cvv2 { get; set; }
        public string ExpireDate { get; set; }
        public string StaticPassword { get; set; }
        public int Amount { get; set; }
        public int Type { get; set; }
        public bool IsBlocked { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}