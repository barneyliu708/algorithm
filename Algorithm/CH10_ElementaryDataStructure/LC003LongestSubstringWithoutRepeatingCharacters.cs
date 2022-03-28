using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC003LongestSubstringWithoutRepeatingCharacters
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

        public class OptimizedSilidingWindowApproach
        {
            public int LengthOfLongestSubstring(string s)
            {
                Dictionary<char, int> map = new Dictionary<char, int>(); // charactor - the latest index of the charactor
                int l = 0;
                int r = 0;
                int ans = 0;
                while (r < s.Length)
                {
                    char rch = s[r];
                    if (map.ContainsKey(rch))
                    {
                        // need to take the greater index between the left pointer and the stored index
                        l = Math.Max(l, map[rch] + 1);
                    }
                    ans = Math.Max(ans, r - l + 1);
                    map[rch] = r;

                    r++;
                }

                return ans;
            }
        }
    }
}
