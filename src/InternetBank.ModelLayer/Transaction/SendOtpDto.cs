using System.ComponentModel.DataAnnotations;
using InternetBank.Validations;

namespace InternetBank.Models
{
    public class SendOtpDto
    {
        [IsValidCardNumber]
        public string SourceCardNumber { get; set; }
        [IsValidCvv2]
        public string Cvv2 { get; set; }
        [IsValidExpireDate]
        public string ExpireDate { get; set; }
        [Range(1000, 5000000)]
        public int Amount { get; set; }
        [IsValidCardNumber]
        public string DestinationCardNumber { get; set; }
    }
}