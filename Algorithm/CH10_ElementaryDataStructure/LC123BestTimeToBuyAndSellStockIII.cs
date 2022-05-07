using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC123BestTimeToBuyAndSellStockIII
    {
        public int MaxProfit(int[] prices)
        {
            int n = prices.Length;

            int minleft = prices[0];
            int[] leftprofits = new int[n];
            for (int l = 1; l < n; l++)
            {
                leftprofits[l] = Math.Max(leftprofits[l - 1], prices[l] - minleft);
                minleft = Math.Min(minleft, prices[l]);
            }

            int maxright = prices[n - 1];
            int[] rightprofits = new int[n];
            for (int r = n - 2; r >= 0; r--)
            {
                rightprofits[r] = Math.Max(rightprofits[r + 1], maxright - prices[r]);
                maxright = Math.Max(maxright, prices[r]);
            }

            int max = 0;
            for (int i = 0; i < n - 1; i++)
            {
                max = Math.Max(max, leftprofits[i] + rightprofits[i]);
            }

            return max;
        }
    }
}
