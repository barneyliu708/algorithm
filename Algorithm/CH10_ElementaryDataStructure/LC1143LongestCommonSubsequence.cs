using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1143LongestCommonSubsequence
    {
        public int LongestCommonSubsequence(string text1, string text2)
        {
            int[,] dp = new int[text1.Length + 1, text2.Length + 1];
            for (int i = 1; i < text1.Length + 1; i++)
            {
                for (int j = 1; j < text2.Length + 1; j++)
                {
                    if (text1[i - 1] == text2[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }
            return dp[text1.Length, text2.Length];
        }
    }
}
