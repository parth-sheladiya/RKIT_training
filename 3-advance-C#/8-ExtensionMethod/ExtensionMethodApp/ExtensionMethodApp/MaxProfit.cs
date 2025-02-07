using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodApp
{
    /// <summary>
    /// number sum
    /// </summary>
    /// <param name="lst">data source</param>

    public static class StockExtensions
    {
        /// <summary>
        /// maxprofit
        /// </summary>
        /// <param name="prices">price</param>
        /// <returns>maxprofit</returns>
        public static int MaxProfit(this List<int> prices)
        {
            if (prices == null || prices.Count < 2)
                return 0;

            int minPrice = int.MaxValue;
            int maxProfit = 0;

            foreach (int price in prices)
            {
                // buy price
                minPrice = Math.Min(minPrice, price);
                // sell price
                maxProfit = Math.Max(maxProfit, price - minPrice); 
            }

            return maxProfit;
        }

    }
}

  
