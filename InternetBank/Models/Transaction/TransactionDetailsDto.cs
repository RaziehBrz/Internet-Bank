using System;

namespace InternetBank.Models
{
    public class TransactionDetailsDto
    {
        public int Amount { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public string DestinationCardNumber { get; set; }
    }
}