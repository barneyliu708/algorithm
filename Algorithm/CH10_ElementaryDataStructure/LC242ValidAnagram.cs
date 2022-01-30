using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC242ValidAnagram
    {
        public bool IsAnagram(string s, string t)
        {

            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (!map.ContainsKey(s[i]))
                {
                    map[s[i]] = 0;
                }
                map[s[i]]++;
            }

            for (int i = 0; i < t.Length; i++)
            {
                if (!map.ContainsKey(t[i]))
                {
                    return false;
                }
                map[t[i]]--;
            }

            foreach (int ct in map.Values)
            {
                if (ct != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
