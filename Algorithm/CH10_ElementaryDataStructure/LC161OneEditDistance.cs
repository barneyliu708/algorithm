using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC161OneEditDistance
    {
        public bool IsOneEditDistance(string s, string t)
        {

            if (s.Length > t.Length)
            {
                return IsOneEditDistance(t, s);
            }

            if (t.Length - s.Length > 1)
            {
                return false;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i])
                {
                    if (s.Length == t.Length)
                    {
                        return s.Substring(i + 1) == t.Substring(i + 1);
                    }
                    else
                    {
                        return s.Substring(i) == t.Substring(i + 1);
                    }
                }
            }

            return s.Length + 1 == t.Length;
        }
    }
}
