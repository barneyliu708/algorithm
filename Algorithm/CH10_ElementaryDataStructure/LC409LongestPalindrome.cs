using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC409LongestPalindrome
    {
        public int LongestPalindrome(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            foreach (char ch in s)
            {
                if (!map.ContainsKey(ch))
                {
                    map[ch] = 0;
                }
                map[ch]++;
            }
            int oddcount = 0;
            foreach (char ch in map.Keys)
            {
                if (map[ch] % 2 == 1)
                {
                    oddcount++;
                }
            }
            // if there is odd count, we should only allow at most one character with odd count
            return oddcount > 0 ? s.Length - oddcount + 1 : s.Length;
        }
    }
}
