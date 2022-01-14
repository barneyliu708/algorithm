using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC064MinimumPathSum
    {
        public int MinPathSum(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            int[,] dp = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = grid[i][j];
                    }
                    else if (i == 0)
                    {
                        dp[i, j] = dp[i, j - 1] + grid[i][j];
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j] + grid[i][j];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i, j - 1], dp[i - 1, j]) + grid[i][j];
                    }
                }
            }

            return dp[m - 1, n - 1];
        }
    }
}
