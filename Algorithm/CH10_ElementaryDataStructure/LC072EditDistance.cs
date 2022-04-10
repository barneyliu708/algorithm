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

        public class DFT_MemorizationApproach
        {
            public int MinDistance(string word1, string word2)
            {
                int[,] memo = new int[word1.Length, word2.Length];
                return MinDistance(word1, 0, word2, 0, memo);
            }

            private int MinDistance(string word1, int i, string word2, int j, int[,] memo)
            {
                if (i == word1.Length)
                {
                    return word2.Length - j;
                }
                if (j == word2.Length)
                {
                    return word1.Length - i;
                }

                if (memo[i, j] != 0)
                {
                    return memo[i, j];
                }

                if (word1[i] == word2[j])
                {
                    return MinDistance(word1, i + 1, word2, j + 1, memo);
                }

                int deleteOnWord1 = MinDistance(word1, i + 1, word2, j, memo);
                int insertOnWord2 = MinDistance(word1, i, word2, j + 1, memo);
                int change = MinDistance(word1, i + 1, word2, j + 1, memo);
                memo[i, j] = Math.Min(Math.Min(deleteOnWord1, insertOnWord2), change) + 1;
                Console.WriteLine(i + " " + j + " " + memo[i, j]);
                return memo[i, j];
            }
        }
    }
}
