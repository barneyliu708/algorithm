using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC221MaximalSquare
    {
        public int MaximalSquare(char[][] matrix)
        {

            int[,] dp = new int[matrix.Length, matrix[0].Length];

            int ans = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        dp[i, j] = matrix[i][j] == '1' ? 1 : 0;
                    }
                    else
                    {
                        dp[i, j] = matrix[i][j] == '1' ?
                                   Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1 :
                                   0;
                    }
                    ans = Math.Max(ans, dp[i, j]);
                }
            }

            return ans * ans;
        }
    }
}
