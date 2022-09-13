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

        public class SecondDone
        {
            public string LongestPalindrome(string s)
            {
                bool[,] dp = new bool[s.Length, s.Length];
                int maxlen = 0;
                (int i, int j) ans = (0, 0);
                for (int j = 0; j < s.Length; j++)
                {
                    for (int i = j; i >= 0; i--)
                    {
                        if (i == j)
                        {
                            dp[i, j] = true;
                        }
                        else if (i + 1 == j && s[i] == s[j])
                        {
                            dp[i, j] = true;
                        }
                        else if (s[i] == s[j])
                        {
                            dp[i, j] = dp[i + 1, j - 1];
                        }

                        if (dp[i, j] && j - i + 1 > maxlen)
                        {
                            maxlen = j - i + 1;
                            ans = (i, j);
                        }
                    }
                }

                return s.Substring(ans.i, ans.j - ans.i + 1);
            }
        }
    }
}
