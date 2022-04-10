using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC072EditDistance
    {
        // should not count each characters as the sequence also matters
        public int MinDistance(string word1, string word2)
        {
            int m = word1.Length;
            int n = word2.Length;
            int[,] dp = new int[m + 1, n + 1];
            // i, j represent the length of substring, not the index
            for (int i = 0; i < m + 1; i++)
            {
                dp[i, 0] = i;
            }
            for (int j = 0; j < n + 1; j++)
            {
                dp[0, j] = j;
            }
            for (int i = 1; i < m + 1; i++)
            {
                for (int j = 1; j < n + 1; j++)
                {
                    if (word1[i - 1] == word2[j - 1])
                    {
                        dp[i, j] = 1 + Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1] - 1);
                    }
                    else
                    {
                        dp[i, j] = 1 + Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]);
                    }
                }
            }
            return dp[m, n];
        }
    }
}
