using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;

namespace InternetBank.Models
{
    public class SendOtpDto
    {
        [ValidIranShetabNumber]
        public string SourceCardNumber { get; set; }
        [MinLength(4)]
        public string Cvv2 { get; set; }
        public string ExpireDate { get; set; }
        [Range(1000, 5000000)]
        public int Amount { get; set; }
        [ValidIranShetabNumber]
        public string DestinationCardNumber { get; set; }
    }
}