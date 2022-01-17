using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC122BestTimeToBuyAndSellStockII
    {
        public int MaxProfit(int[] prices)
        {

            int ans = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    ans += prices[i] - prices[i - 1];
                }
            }

            return ans;
        }
    }
}
