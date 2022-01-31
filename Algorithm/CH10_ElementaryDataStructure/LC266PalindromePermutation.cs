
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC266PalindromePermutation
    {
        public bool CanPermutePalindrome(string s)
        {

            Dictionary<char, int> map = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                {
                    map[s[i]] = 0;
                }
                map[s[i]]++;
            }

            int oddCount = 0;
            foreach (char key in map.Keys)
            {
                oddCount += map[key] % 2;
            }

            return oddCount <= 1;
        }
    }
}
