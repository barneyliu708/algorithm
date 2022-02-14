using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC028ImplementstrStr
    {
        public int StrStr(string haystack, string needle)
        {

            if (needle.Length == 0)
            {
                return 0;
            }

            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                int j = 0;
                for (; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j])
                    {
                        break;
                    }
                }
                if (j == needle.Length)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
