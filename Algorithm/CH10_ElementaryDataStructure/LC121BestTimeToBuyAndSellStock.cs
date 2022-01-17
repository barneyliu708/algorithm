using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC121BestTimeToBuyAndSellStock
    {
        public int MaxProfit(int[] prices)
        {

            int curMinPrice = prices[0];
            int curMaxProfit = 0;

            for (int i = 1; i < prices.Length; i++)
            {
                curMaxProfit = Math.Max(curMaxProfit, prices[i] - curMinPrice);
                curMinPrice = Math.Min(curMinPrice, prices[i]);
            }

            return curMaxProfit;
        }
    }
}
