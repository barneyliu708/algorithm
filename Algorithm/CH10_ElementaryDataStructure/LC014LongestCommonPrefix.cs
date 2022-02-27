using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC014LongestCommonPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }
            for (int i = 0; i < strs[0].Length; i++)
            {
                char ch = strs[0][i];
                for (int j = 1; j < strs.Length; j++)
                {
                    if (i == strs[j].Length || strs[j][i] != ch)
                    {
                        return strs[0].Substring(0, i);
                    }
                }
            }
            return strs[0];
        }
    }
}
