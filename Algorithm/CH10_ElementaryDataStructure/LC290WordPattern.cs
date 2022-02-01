using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC290WordPattern
    {
        public bool WordPattern(string pattern, string s)
        {

            string[] sl = s.Split(' ');

            if (pattern.Length != sl.Length)
            {
                return false;
            }

            Dictionary<char, string> mapptos = new Dictionary<char, string>();
            Dictionary<string, char> mapstop = new Dictionary<string, char>();

            for (int i = 0; i < pattern.Length; i++)
            {
                if (mapptos.ContainsKey(pattern[i]) && mapptos[pattern[i]] != sl[i])
                {
                    return false;
                }

                if (mapstop.ContainsKey(sl[i]) && mapstop[sl[i]] != pattern[i])
                {
                    return false;
                }

                mapptos[pattern[i]] = sl[i];
                mapstop[sl[i]] = pattern[i];
            }

            return true;
        }
    }
}
