using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC187RepeatedDNASequences
    {
        public IList<string> FindRepeatedDnaSequences(string s)
        {

            HashSet<string> hashset = new HashSet<string>();
            HashSet<string> ans = new HashSet<string>();
            for (int i = 0; i < s.Length - 9; i++)
            {
                string substr = s.Substring(i, 10);
                if (hashset.Contains(substr))
                {
                    ans.Add(substr);
                }
                else
                {
                    hashset.Add(substr);
                }
            }
            return ans.ToList();
        }
    }
}
