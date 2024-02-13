namespace InternetBank.Data
{
    public class Transaction : BaseEntity
    {
        public bool Status { get; set; }
        public int AccountId { get; set; }
        public string Description { get; set; }
        public string DestinationCardNumber { get; set; }
        public Account Account { get; set; }
    }
}