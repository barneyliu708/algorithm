﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC091DecodeWays
    {
        public int NumDecodings(string s)
        {

            if (s == null || s.Length == 0 || s[0] == '0')
            {
                return 0;
            }

            if (s.Length == 1)
            {
                return 1;
            }

            int[] dp = new int[s.Length];
            dp[0] = 1;
            if (s[1] != '0')
            {
                dp[1] = dp[0];
            }
            int first2Digit = int.Parse(s.Substring(0, 2));
            if (first2Digit >= 10 && first2Digit <= 26)
            {
                dp[1] += 1;
            }

            for (int i = 2; i < s.Length; i++)
            {
                if (s[i] != '0')
                {
                    dp[i] = dp[i - 1];
                }
                int twoDigit = int.Parse(s.Substring(i - 1, 2));
                if (twoDigit >= 10 && twoDigit <= 26)
                {
                    dp[i] += dp[i - 2];
                }
            }

            return dp[s.Length - 1];
        }

        public class BottomUp_DP
        {
            public int NumDecodings(string s)
            {
                int[] dp = new int[s.Length + 1];
                if (s[0] == '0')
                {
                    return 0;
                }
                dp[0] = 1;
                dp[1] = 1;
                for (int i = 2; i < s.Length + 1; i++)
                {
                    if (s[i - 1] != '0')
                    {
                        dp[i] += dp[i - 1];
                    }
                    int twoDigit = int.Parse(s.Substring(i - 2, 2));
                    if (twoDigit >= 10 && twoDigit <= 26)
                    {
                        dp[i] += dp[i - 2];
                    }
                }
                return dp[s.Length];
            }
        }

        public class ThirdDone
        {
            public int NumDecodings(string s)
            {
                int[] dp = new int[s.Length];
                if (s[0] == '0')
                {
                    return 0;
                }
                if (s.Length == 1)
                {
                    return 1;
                }
                dp[0] = 1;
                if (s[1] != '0')
                {
                    dp[1] = dp[0];
                }
                if (int.Parse(s.Substring(0, 2)) <= 26)
                {
                    dp[1] += 1;
                }

                for (int i = 2; i < s.Length; i++)
                {
                    if (s[i] != '0')
                    {
                        dp[i] = dp[i - 1];
                    }
                    if (s[i - 1] != '0' && int.Parse(s.Substring(i - 1, 2)) <= 26)
                    {
                        dp[i] += dp[i - 2];
                    }
                }

                return dp[s.Length - 1];
            }
        }

        public class ForthDone
        {
            public int NumDecodings(string s)
            {
                int[] dp = new int[s.Length + 1];
                dp[0] = 1;
                if (s[0] == '0')
                {
                    return 0;
                }
                dp[1] += dp[0];
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] != '0')
                    {
                        dp[i + 1] += dp[i];
                    }
                    if (s[i - 1] != '0' && int.Parse(s.Substring(i - 1, 2)) <= 26)
                    {
                        dp[i + 1] += dp[i - 1];
                    }
                }

                return dp[s.Length];
            }
        }
    }
}
