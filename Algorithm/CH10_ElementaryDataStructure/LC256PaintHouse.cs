using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    class LC256PaintHouse
    {
        public int MinCost(int[][] costs)
        {
            int n = costs.Length;
            int color = costs[0].Length;
            int[,] dp = new int[costs.Length, color];

            dp[0, 0] = costs[0][0];
            dp[0, 1] = costs[0][1];
            dp[0, 2] = costs[0][2];
            for (int i = 1; i < costs.Length; i++)
            {
                dp[i, 0] = Math.Min(dp[i - 1, 1], dp[i - 1, 2]) + costs[i][0];
                dp[i, 1] = Math.Min(dp[i - 1, 0], dp[i - 1, 2]) + costs[i][1];
                dp[i, 2] = Math.Min(dp[i - 1, 0], dp[i - 1, 1]) + costs[i][2];
            }

            return Math.Min(Math.Min(dp[n - 1, 0], dp[n - 1, 1]), dp[n - 1, 2]);
        }

        public class TopDown_DP
        {
            public int MinCost(int[][] costs)
            {
                int[,] memo = new int[costs.Length, 3];
                int ans = int.MaxValue;
                for (int icolor = 0; icolor < 3; icolor++)
                {
                    ans = Math.Min(ans, MinCost(costs, 0, icolor, memo));
                }
                return ans;
            }

            private int MinCost(int[][] costs, int ihouse, int icolor, int[,] memo)
            {
                if (ihouse == costs.Length)
                {
                    return 0;
                }

                if (memo[ihouse, icolor] != 0)
                {
                    return memo[ihouse, icolor];
                }

                int ans = int.MaxValue;
                for (int jcolor = 0; jcolor < 3; jcolor++)
                {
                    if (jcolor != icolor)
                    {
                        ans = Math.Min(ans, MinCost(costs, ihouse + 1, jcolor, memo));
                    }
                }
                ans += costs[ihouse][icolor];

                memo[ihouse, icolor] = ans;
                return ans;
            }
        }

        [Test] 
        public void TestCase1()
        {
            int[][] costs = new int[][]
            {
                new int[] {3, 5, 3},
                new int[] {6, 17, 6},
                new int[] {7, 13, 18},
                new int[] {9, 10, 18},
            };

            int result = new TopDown_DP().MinCost(costs);
        }
    }
}
