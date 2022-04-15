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

        public class SecondDone
        {
            public int MaxProfit(int[] prices)
            {
                int[] minprices = new int[prices.Length];
                int min = prices[0];
                for (int i = 0; i < prices.Length; i++)
                {
                    min = Math.Min(min, prices[i]);
                    minprices[i] = min;
                }
                int maxProfit = 0;
                for (int i = 0; i < prices.Length; i++)
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - minprices[i]);
                }
                return maxProfit;
            }
        }
    }
}
