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

        public class ThirdDone
        {
            // s.........x........x
            // istart....idup.....i
            public int LengthOfLongestSubstring(string s)
            {
                Dictionary<char, int> map = new Dictionary<char, int>(); // char - latest index
                HashSet<char> subset = new HashSet<char>();
                int istart = 0;
                int ans = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    char ch = s[i];
                    if (subset.Contains(ch))
                    {
                        int idup = map[ch];
                        while (istart <= idup)
                        {
                            subset.Remove(s[istart]);
                            istart++;
                        }
                    }
                    subset.Add(ch);
                    map[ch] = i;
                    ans = Math.Max(ans, subset.Count);
                }

                return ans;
            }
        }

        public class ForthDone
        {
            public int LengthOfLongestSubstring(string s)
            {
                Dictionary<char, int> map = new Dictionary<char, int>(); // char - latest index
                int l = 0;
                int r = 0;
                int ans = 0;
                while (r < s.Length)
                {
                    char rch = s[r];
                    if (!map.ContainsKey(rch))
                    {
                        map[rch] = r;
                    }
                    else
                    {
                        l = Math.Max(l, map[rch] + 1); // the last index of rch could be on the left of the l pointer
                        map[rch] = r;
                    }
                    ans = Math.Max(ans, r - l + 1);
                    r++;
                }
                return ans;
            }
        }
    }
}
