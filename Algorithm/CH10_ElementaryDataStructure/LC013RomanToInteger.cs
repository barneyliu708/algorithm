using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC013RomanToInteger
    {
        public int RomanToInt(string s)
        {

            Dictionary<char, int> map = new Dictionary<char, int>() {
                { 'M', 1000 },
                { 'D', 500 },
                { 'C', 100 },
                { 'L', 50 },
                { 'X', 10 },
                { 'V', 5 },
                { 'I', 1 },
            };

            int ans = 0;
            for (int i = 0; i < s.Length;)
            {
                if (i + 1 < s.Length && map[s[i]] < map[s[i + 1]])
                {
                    ans += map[s[i + 1]] - map[s[i]];
                    i += 2;
                }
                else
                {
                    ans += map[s[i]];
                    i++;
                }
            }

            return ans;
        }
    }
}
