using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC159LongestSubstringWithAtMostTwoDistinctCharacters
    {
        public int LengthOfLongestSubstring(string s)
        {

            int[] chars = new int[128];

            int left = 0;
            int right = 0;

            int ans = 0;
            while (right < s.Length)
            {
                char r = s[right];
                chars[r]++;

                while (chars[r] > 1)
                {
                    char l = s[left];
                    chars[l]--;
                    left++;
                }

                ans = Math.Max(ans, right - left + 1);

                right++;
            }

            return ans;
        }
    }
}
