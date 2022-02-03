using System;
using System.Collections.Generic;
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
    }
}
