using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC383RansomNote
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {

            Dictionary<char, int> countMap = new Dictionary<char, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (!countMap.ContainsKey(magazine[i]))
                {
                    countMap[magazine[i]] = 0;
                }
                countMap[magazine[i]]++;
            }

            for (int i = 0; i < ransomNote.Length; i++)
            {
                char ch = ransomNote[i];
                if (!countMap.ContainsKey(ch))
                {
                    return false;
                }
                if (countMap[ch] <= 0)
                {
                    return false;
                }
                countMap[ch]--;
            }

            return true;
        }
    }
}
