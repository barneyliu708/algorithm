using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC309BestTimeToBuyAndSellStockWithCooldown
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;
            int[] buy = new int[n];
            int[] sell = new int[n];
            int[] rest = new int[n];

            buy[0] = -prices[0];
            for (int i = 1; i < n; i++)
            {
                buy[i] = Math.Max(rest[i - 1] - prices[i], buy[i - 1]);
                sell[i] = Math.Max(buy[i - 1] + prices[i], sell[i - 1]);
                rest[i] = Math.Max(Math.Max(buy[i - 1], sell[i - 1]), rest[i - 1]);
            }


            return Math.Max(Math.Max(buy[n - 1], sell[n - 1]), rest[n - 1]);
        }
    }
}
