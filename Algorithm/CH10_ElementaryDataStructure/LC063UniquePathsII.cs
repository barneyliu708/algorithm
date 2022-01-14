using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC063UniquePathsII
    {
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            int m = obstacleGrid.Length;
            int n = obstacleGrid[0].Length;
            int[,] dp = new int[m, n];

            if (obstacleGrid[0][0] == 0)
            {
                dp[0, 0] = 1;
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    if (obstacleGrid[i][j] == 0)
                    {
                        dp[i, j] = UniquePaths(obstacleGrid, dp, i, j - 1) + UniquePaths(obstacleGrid, dp, i - 1, j);
                    }
                }
            }

            return dp[m - 1, n - 1];
        }

        private int UniquePaths(int[][] obstacleGrid, int[,] dp, int i, int j)
        {

            if (i < 0 || i >= dp.GetLength(0) ||
                j < 0 || j >= dp.GetLength(1) ||
                obstacleGrid[i][j] == 1)
            {
                return 0;
            }

            return dp[i, j];
        }
    }
}
