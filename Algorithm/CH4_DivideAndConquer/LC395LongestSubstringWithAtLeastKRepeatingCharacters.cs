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

        public class SlidingWindowApproach 
        {
            public int LongestSubstring(string s, int k)
            {
                HashSet<char> uniqueChars = new HashSet<char>();
                foreach (char ch in s)
                {
                    uniqueChars.Add(ch);
                }

                int ans = 0;
                for (int unique = 1; unique <= uniqueChars.Count; unique++)
                {
                    ans = Math.Max(ans, LongestSubstring(s, k, unique));
                }

                return ans;
            }

            private int LongestSubstring(string s, int k, int unique)
            {
                int ans = 0;
                Dictionary<char, int> counts = new Dictionary<char, int>(); // character - the count of the character
                HashSet<char> goodChars = new HashSet<char>(); // the characters whose count equals or is greater than k

                // sliding windows to find the longest substring that satisfy the required conditions
                int l = 0;
                int r = 0;
                while (r < s.Length)
                {
                    char rch = s[r];
                    if (!counts.ContainsKey(rch))
                    {
                        counts[rch] = 0;
                    }
                    counts[rch]++;

                    if (counts[rch] >= k)
                    {
                        goodChars.Add(rch);
                    }

                    while (counts.Keys.Count > unique)
                    {
                        char lch = s[l];
                        counts[lch]--;
                        if (counts[lch] < k)
                        {
                            goodChars.Remove(lch);
                        }
                        if (counts[lch] == 0)
                        {
                            counts.Remove(lch);
                        }
                        l++;
                    }

                    if (goodChars.Count == unique)
                    {
                        ans = Math.Max(ans, r - l + 1);
                    }

                    r++;
                }

                return ans;
            }
        }

    }
}
