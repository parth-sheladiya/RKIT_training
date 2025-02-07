using System;


namespace ExtensionMethodApp
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> prices = new List<int> { 7, 1, 5, 3, 6, 4 };

            // maxprofit
            int maxProfit = prices.MaxProfit();
            Console.WriteLine($"Max Profit (One Transaction): {maxProfit}");

        }
    }
}
