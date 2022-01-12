using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC005LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s)
        {

            bool[,] dp = new bool[s.Length, s.Length];
            int maxLen = 1; int left = 0;

            for (int i = 0; i < s.Length; i++)
            {
                dp[i, i] = true;

                for (int l = 0; l < i; l++)
                {
                    if (l == i - 1)
                    {
                        dp[l, i] = s[l] == s[i];
                    }
                    else
                    {
                        dp[l, i] = s[l] == s[i] && dp[l + 1, i - 1];
                    }

                    if (dp[l, i] && maxLen < i - l + 1)
                    { // update the current max lengh info
                        maxLen = i - l + 1;
                        left = l;
                    }
                }
            }

            return s.Substring(left, maxLen);
        }
    }
}
