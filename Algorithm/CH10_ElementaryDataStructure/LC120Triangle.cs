﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC120Triangle
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {

            int[][] dp = new int[triangle.Count][];
            int ans = int.MaxValue;

            for (int rowIndex = 0; rowIndex < triangle.Count; rowIndex++)
            {
                dp[rowIndex] = new int[rowIndex + 1];
                for (int i = 0; i <= rowIndex; i++)
                {

                    if (rowIndex == 0)
                    {
                        dp[rowIndex][i] = triangle[rowIndex][i];
                    }
                    else if (i == 0)
                    {
                        dp[rowIndex][i] = triangle[rowIndex][i] + dp[rowIndex - 1][i];
                    }
                    else if (i == rowIndex)
                    {
                        dp[rowIndex][i] = triangle[rowIndex][i] + dp[rowIndex - 1][i - 1];
                    }
                    else
                    {
                        dp[rowIndex][i] = triangle[rowIndex][i] + Math.Min(dp[rowIndex - 1][i], dp[rowIndex - 1][i - 1]);
                    }

                    if (rowIndex == triangle.Count - 1)
                    {
                        ans = Math.Min(ans, dp[rowIndex][i]);
                    }
                }
            }

            return ans;
        }
    }
}
