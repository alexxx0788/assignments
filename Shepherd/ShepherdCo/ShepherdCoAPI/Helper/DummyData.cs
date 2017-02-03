using System;
using System.Linq;
using ShepherdCoAPI.Model;

namespace ShepherdCoAPI.Helper
{
    public static class DummyData
    {
        private const string Chars = "qazxswedcvfrtgbnhyujmkiolp";
        public static User GetTestUser()
        {
            return new User()
            {
                Balance = 10000,
                Login = "TestUser"
            };
        }
        public static Stock GetTestCompanyStock()
        {
            return new Stock()
            {
                Amount = 100,
                Company = GetTestCompanyName(),
                Price = GetTestStockPrice() 
            };
        }

        public static string GetTestCompanyName()
        {
            var random = new Random();
            return new string(Enumerable.Repeat(Chars, 3)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static double GetTestStockPrice()
        {
            var random = new Random();
            var i = random.Next(2, 200);
            var d = random.Next(10, 99);
            return double.Parse($"{i},{d}");
        }

        public static double GetRandomCurrentPrice(double price)
        {
            double currPrice = 0;
            while (currPrice == 0)
            {
                Random random = new Random();
                var percentage = random.NextDouble() * (0.1 - (-0.1)) + (-0.1);
                currPrice = Math.Round(price + (percentage * price) / 100, 2);
                return currPrice;
            }
            return currPrice;
        }

        public static double GetPersentage(double previusPrice, double currentPrice)
        {
            var diff = currentPrice - previusPrice;
            var persentage = (diff / currentPrice) * 100;
            return persentage;
        }

        public static StockView AdaptToStockView(Stock stock)
        {
            var currPrice = GetRandomCurrentPrice(stock.Price);
            var changeDelta = Math.Round(currPrice - stock.Price, 3);
            var changeDeltaPersentage = Math.Round(GetPersentage(stock.Price, currPrice), 3);
            var stockView =  new StockView()
                {
                    StockId = stock.StockId,
                    Company = stock.Company,
                    Price = currPrice,
                    Change = changeDelta,
                    ChangePersentage = changeDeltaPersentage,
                    Amount = stock.Amount
            };
            return stockView;
        }

    }
}
