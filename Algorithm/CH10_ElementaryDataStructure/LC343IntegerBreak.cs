using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC343IntegerBreak
    {
        public int IntegerBreak(int n)
        {

            int[] dp = new int[n + 1];
            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;
            for (int i = 3; i <= n; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    dp[i] = Math.Max(dp[i], Math.Max(dp[j] * (i - j), j * (i - j)));

                }
            }

            return dp[n];
        }
    }
}
