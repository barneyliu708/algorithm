using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC279PerfectSquares
    {
        public int NumSquares(int n)
        {

            int[] dp = new int[n + 1];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;
            }
            dp[0] = 0;

            int maxSqrIndx = (int)Math.Sqrt(n) + 1;
            int[] squares = new int[maxSqrIndx];
            for (int i = 1; i < maxSqrIndx; i++)
            {
                squares[i] = i * i;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int s = 1; s < maxSqrIndx; s++)
                {
                    if (i < squares[s])
                    {
                        break;
                    }

                    dp[i] = Math.Min(dp[i], dp[i - squares[s]] + 1);
                }
            }

            return dp[n];
        }
    }
}
