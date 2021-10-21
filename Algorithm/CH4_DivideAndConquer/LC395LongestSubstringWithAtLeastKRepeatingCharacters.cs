using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH4_DivideAndConque
{
    [TestFixture]
    public class LC395LongestSubstringWithAtLeastKRepeatingCharacters
    {
        public int LongestSubstring(string s, int k)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }
            return LongestSubstring(s, k, 0, s.Length - 1);
        }

        public int LongestSubstring(string s, int k, int l, int r)
        {
            if (r - l + 1 < k)
            {
                return 0;
            }

            int[] countMap = new int[26];
            for (int i = l; i <= r; i++)
            {
                countMap[s[i] - 'a']++;
            }

            for (int i = l; i <= r; i++)
            {
                if (countMap[s[i] - 'a'] >= k)
                {
                    continue;
                }

                int mid = i;
                int mid_next = i + 1;
                // skip all the characters whose count is less than k
                while (mid_next <= r && countMap[s[mid_next] - 'a'] < k)
                {
                    mid_next++;
                }

                return Math.Max(LongestSubstring(s, k, l, mid - 1), LongestSubstring(s, k, mid_next, r));
            }

            return r - l + 1;
        }
    }
}
