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
    }
}
