using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC392IsSubsequence
    {
        public bool IsSubsequence(string s, string t)
        {

            int l = 0;
            int r = 0;

            while (l < s.Length && r < t.Length)
            {
                if (s[l] == t[r])
                {
                    l++;
                }
                r++;
            }

            return l == s.Length;
        }
    }
}
