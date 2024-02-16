namespace InternetBank.Service
{
    public interface IRandomService
    {
        string AccountNumberGenerator(int type, int userId);
        string CardNumberGenerator();
        string Cvv2Generator();
        public string PasswordGenerator();

    }
}