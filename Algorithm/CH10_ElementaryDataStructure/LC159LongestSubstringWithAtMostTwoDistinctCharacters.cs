using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC159LongestSubstringWithAtMostTwoDistinctCharacters
    {
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            if (s.Length <= 2)
            {
                return s.Length;
            }

            int l = 0;
            int r = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();

            int ans = 0;
            while (r < s.Length)
            {

                map[s[r]] = r; // need to store the latest index of each charactor

                if (map.Count > 2)
                {
                    int leftmost = map.Values.ToArray().Min();
                    map.Remove(s[leftmost]);
                    l = leftmost + 1;
                }

                ans = Math.Max(ans, r - l + 1);

                r++;
            }

            return ans;
        }
    }
}
