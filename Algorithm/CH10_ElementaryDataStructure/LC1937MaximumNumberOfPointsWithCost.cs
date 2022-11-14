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

        public class SecondDone
        {
            public long MaxPoints(int[][] points)
            {
                int m = points.Length;
                int n = points[0].Length;
                long[] dp = new long[n];
                for (int i = 0; i < m; i++)
                {
                    long[] leftmost = new long[n];
                    long[] rightmost = new long[n];
                    for (int j = 0; j < n; j++)
                    {
                        if (j == 0)
                        {
                            leftmost[j] = dp[j];
                            rightmost[n - 1 - j] = dp[n - 1 - j];
                        }
                        else
                        {
                            leftmost[j] = Math.Max(leftmost[j - 1], dp[j] + j);
                            rightmost[n - 1 - j] = Math.Max(rightmost[n - j], dp[n - 1 - j] + j);
                        }
                    }

                    for (int j = 0; j < n; j++)
                    {
                        dp[j] = points[i][j] + Math.Max(leftmost[j] - j, rightmost[j] - (n - 1 - j));
                    }

                    // Console.WriteLine("i = " + i);
                    // Console.WriteLine(string.Join(", ", leftmost));
                    // Console.WriteLine(string.Join(", ", rightmost));
                    // Console.WriteLine(string.Join(", ", dp));
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
}
