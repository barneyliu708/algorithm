using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC070ClimbingStairs
    {
        public int ClimbStairs(int n)
        {
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    dp[i] = 1;
                }
                else if (i == 1)
                {
                    dp[i] = 2;
                }
                else
                {
                    dp[i] = dp[i - 1] + dp[i - 2];
                }
            }

            return dp[n - 1];
        }
    }
}
