using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1140StoneGameII
    {
        public int StoneGameII(int[] piles)
        {
            int n = piles.Length;

            int[] postSum = new int[n];
            postSum[n - 1] = piles[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                postSum[i] += postSum[i + 1] + piles[i];
            }

            // the current state is determined by the current index and the current M value
            int[,] dp = new int[n + 1, n + 1];
            for (int i = n - 1; i >= 0; i--)
            {
                dp[i, n] = postSum[i];
            }
            for (int i = n - 1; i >= 0; i--)
            {
                for (int m = n - 1; m >= 1; m--)
                {
                    for (int x = 1; x <= 2 * m && i + x <= n; x++)
                    {
                        dp[i, m] = Math.Max(dp[i, m], postSum[i] - dp[i + x, Math.Max(m, x)]);
                    }
                }
            }

            return dp[0, 1];
        }
    }
}
