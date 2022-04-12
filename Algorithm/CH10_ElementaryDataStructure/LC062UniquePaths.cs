using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC062UniquePaths
    {
        public int UniquePaths(int m, int n)
        {
            int[,] dp = new int[m, n];

            dp[0, 0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    dp[i, j] = UniquePaths(dp, i, j - 1) + UniquePaths(dp, i - 1, j);
                }
            }

            return dp[m - 1, n - 1];
        }

        private int UniquePaths(int[,] dp, int i, int j)
        {

            if (i < 0 || i >= dp.GetLength(0) ||
                j < 0 || j >= dp.GetLength(1))
            {
                return 0;
            }

            return dp[i, j];
        }

        public class SecondDone
        {
            public int UniquePaths(int m, int n)
            {
                int[,] dp = new int[m + 1, n + 1];
                dp[0, 1] = 1;
                for (int i = 1; i < m + 1; i++)
                {
                    for (int j = 1; j < n + 1; j++)
                    {
                        dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
                    }
                }
                return dp[m, n];
            }
        }

        public class SecondDone_DP_TopDownApproach
        {
            public int UniquePaths(int m, int n)
            {
                return UniquePath(m - 1, n - 1, new int[m, n]);
            }

            private int UniquePath(int m, int n, int[,] memo)
            {
                if (m == 0 || n == 0)
                {
                    return 1;
                }
                if (memo[m, n] != 0)
                {
                    return memo[m, n];
                }
                memo[m, n] = UniquePath(m, n - 1, memo) + UniquePath(m - 1, n, memo);
                return memo[m, n];
            }
        }
    }
}
