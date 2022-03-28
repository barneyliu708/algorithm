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

        public class StandardSlidingWidnowTemplateApproach
        {
            public int LengthOfLongestSubstringTwoDistinct(string s)
            {
                Dictionary<char, int> map = new Dictionary<char, int>();
                int l = 0;
                int r = 0;
                int ans = 0;
                while (r < s.Length)
                {
                    // update the state of the sliding window with the right index
                    char rch = s[r];
                    if (!map.ContainsKey(rch))
                    {
                        map[rch] = 0;
                    }
                    map[rch]++;

                    // check if the current substring satisfy the target condition
                    while (map.Count > 2)
                    {
                        char lch = s[l];
                        map[lch]--;
                        if (map[lch] == 0)
                        {
                            map.Remove(lch);
                        }
                        l++;
                    }

                    // update the answer
                    ans = Math.Max(ans, r - l + 1);

                    r++;
                }

                return ans;
            }
        }
    }
}
