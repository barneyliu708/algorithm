using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC205IsomorphicStrings
    {
        public bool IsIsomorphic(string s, string t)
        {

            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, char> mapstot = new Dictionary<char, char>();
            Dictionary<char, char> mapttos = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if ((mapstot.ContainsKey(s[i]) && mapstot[s[i]] != t[i]) ||
                    (mapttos.ContainsKey(t[i]) && mapttos[t[i]] != s[i]))
                {
                    return false;
                }

                mapstot[s[i]] = t[i];
                mapttos[t[i]] = s[i];
            }

            return true;
        }
    }
}
