using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC340LongestSubstringWithAtMostKDistinctCharacters
    {
        public int LengthOfLongestSubstringKDistinct(string s, int k)
        {

            Dictionary<char, int> map = new Dictionary<char, int>();

            int l = 0;
            int r = 0;

            int ans = 0;
            while (r < s.Length)
            {
                char rch = s[r];
                if (!map.ContainsKey(rch))
                {
                    map[rch] = 0;
                }
                map[rch]++;

                while (map.Keys.Count > k)
                {
                    char lch = s[l];

                    // move left indice to the right and reduce the count of the left char
                    l++;
                    map[lch]--;

                    // check if need to remove the left key from the map if the count is 0;
                    if (map[lch] == 0)
                    {
                        map.Remove(lch);
                    }
                }

                ans = Math.Max(ans, r - l + 1);

                r++;
            }

            return ans;
        }

        public class OptimizedSlidingWindow
        {
            public int LengthOfLongestSubstringKDistinct(string s, int k)
            {
                // character - the latest indice of the character
                // sliding window to find the longest substring that satisfy the required conditions
                Dictionary<char, int> map = new Dictionary<char, int>(); 
                int l = 0;
                int r = 0;
                int ans = 0;
                while (r < s.Length)
                {
                    char rch = s[r];
                    if (!map.ContainsKey(rch))
                    {
                        map[rch] = -1;
                    }
                    map[rch] = r;

                    // if the count of unique characters are greater than k, shrink the substring
                    if (map.Keys.Count > k)
                    {
                        l = map.Values.Min(); // the indice of the character to be removed
                        char lch = s[l];
                        map.Remove(lch);
                        l++; // move to next character
                    }

                    ans = Math.Max(ans, r - l + 1);
                    r++;
                }

                return ans;
            }
        }

        public class OptimizedSlidingWindowThatNeverShrink
        {
            public int LengthOfLongestSubstringKDistinct(string s, int k)
            {
                // character - count
                // sliding window to find the longest substring that satisfy the required conditions
                Dictionary<char, int> map = new Dictionary<char, int>(); 
                int l = 0;
                int r = 0;
                while (r < s.Length)
                {
                    char rch = s[r];
                    if (!map.ContainsKey(rch))
                    {
                        map[rch] = 0;
                    }
                    map[rch]++;

                    // if the count of unique characters are greater than k, move the left pointer once, but never shrink the window
                    if (map.Keys.Count > k)
                    {
                        char lch = s[l]; // character to be removed
                        map[lch]--;
                        if (map[lch] == 0)
                        {
                            map.Remove(lch);
                        }
                        l++;
                    }

                    r++;
                }

                return r - l;
            }
        }
    }
}
