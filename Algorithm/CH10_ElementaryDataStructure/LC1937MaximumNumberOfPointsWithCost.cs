using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1937MaximumNumberOfPointsWithCost
    {
        public long MaxPoints(int[][] points)
        {

            int m = points.Length;
            int n = points[0].Length;

            long[] lmax = new long[n];
            long[] rmax = new long[n];
            long[] dp = new long[n];
            for (int i = 0; i < m; i++)
            {

                lmax[0] = dp[0];
                for (int j = 1; j < n; j++)
                {
                    lmax[j] = Math.Max(lmax[j - 1], dp[j] + j); // when looking towards left, the closer, the bigger
                }

                rmax[n - 1] = dp[n - 1] - (n - 1);
                for (int j = n - 2; j >= 0; j--)
                {
                    rmax[j] = Math.Max(rmax[j + 1], dp[j] - j); // when looking towards right, the closer, the bigger
                }

                for (int j = 0; j < n; j++)
                {
                    dp[j] = points[i][j] + Math.Max(lmax[j] - j, rmax[j] + j);
                }
            }

            long ans = 0;
            for (int j = 0; j < n; j++)
            {
                ans = Math.Max(ans, dp[j]);
            }
            return ans;
        }
    }
}
