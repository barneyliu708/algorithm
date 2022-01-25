using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC049GroupAnagrams
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {

            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();

            foreach (string str in strs)
            {
                string hash = Hash(str);
                if (map.ContainsKey(hash))
                {
                    map[hash].Add(str);
                }
                else
                {
                    map[hash] = new List<string>();
                    map[hash].Add(str);
                }
            }

            return map.Values.ToList();
        }

        private string Hash(string str)
        {
            int[] count = new int[26];
            for (int i = 0; i < str.Length; i++)
            {
                count[str[i] - 'a']++;
            }

            StringBuilder sb = new StringBuilder();
            foreach (int c in count)
            {
                sb.Append("#" + c.ToString());
            }

            return sb.ToString();
        }
    }
}
