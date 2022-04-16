using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC712MinimumASCIIDeleteSumForTwoStrings
    {
        public int MinimumDeleteSum(string s1, string s2)
        {
            int m = s1.Length;
            int n = s2.Length;
            int[,] dp = new int[m + 1, n + 1];
            for (int i = 1; i < m + 1; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + (int)s1[i - 1];
            }
            for (int j = 1; j < n + 1; j++)
            {
                dp[0, j] = dp[0, j - 1] + (int)s2[j - 1];
            }
            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j - 1], Math.Min(dp[i - 1, j] + (int)s1[i - 1], dp[i, j - 1] + (int)s2[j - 1]));
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j - 1] + (int)s1[i - 1] + (int)s2[j - 1], Math.Min(dp[i - 1, j] + (int)s1[i - 1], dp[i, j - 1] + (int)s2[j - 1]));
                    }
                }
            }
            return dp[m, n];
        }
    }
}
