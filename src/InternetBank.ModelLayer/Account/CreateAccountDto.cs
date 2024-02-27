using System.ComponentModel.DataAnnotations;

namespace InternetBank.Models
{
    public class CreateAccountDto
    {
        public int Type { get; set; }
        [Range(10000, long.MaxValue)]
        public int Amount { get; set; }
    }
}