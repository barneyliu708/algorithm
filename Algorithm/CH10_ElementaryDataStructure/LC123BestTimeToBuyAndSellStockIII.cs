﻿using System;
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

        public class SecondDone
        {
            public int MaxProfit(int[] prices)
            {
                int n = prices.Length;

                int[] leftprofits = new int[n];
                int min = prices[0];
                for (int i = 1; i < n; i++)
                {
                    leftprofits[i] = Math.Max(leftprofits[i - 1], prices[i] - min);
                    min = Math.Min(min, prices[i]);
                }

                int[] rightprofits = new int[n];
                int max = prices[n - 1];
                for (int i = n - 2; i >= 0; i--)
                {
                    rightprofits[i] = Math.Max(rightprofits[i + 1], max - prices[i]);
                    max = Math.Max(max, prices[i]);
                }

                int ans = 0;
                for (int i = 1; i < n; i++)
                {
                    if (i == n - 1)
                    {
                        ans = Math.Max(ans, leftprofits[i]);
                    }
                    else
                    {
                        ans = Math.Max(ans, leftprofits[i] + rightprofits[i + 1]);
                    }
                }

                return ans;
            }
        }
    }
}
