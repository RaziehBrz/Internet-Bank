using System;

namespace InternetBank.Service
{
    public class RandomService : IRandomService
    {
        private readonly Random _random;
        public RandomService()
        {
            _random = new Random();
        }
        public string AccountNumberGenerator(int type, int userId)
        {
            var firstPart = _random.Next(10, 100).ToString();

            var secondPart = userId.ToString();
            if (secondPart.Length == 1) secondPart = "00" + secondPart;
            else if (secondPart.Length == 2) secondPart = "0" + secondPart;

            var thirdPard = _random.Next(1000, 10000).ToString();
            var fourthPart = type.ToString();

            return firstPart + secondPart + thirdPard + fourthPart;
        }
        public string CardNumberGenerator()
        {
            var cardNumber = "";
            for (int i = 0; i < 4; i++)
            {
                cardNumber += _random.Next(1000, 10000).ToString();
            }
            return cardNumber;
        }
        public string Cvv2Generator()
        {
            return _random.Next(1000, 10000).ToString();
        }
        public string PasswordGenerator()
        {
            return _random.Next(100000, 1000000).ToString();
        }

    }
}