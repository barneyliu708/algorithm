using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC249GroupShiftedStrings
    {
        public IList<IList<string>> GroupStrings(string[] strings)
        {

            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();

            foreach (string str in strings)
            {
                string hashstr = HashStr(str);
                if (!map.ContainsKey(hashstr))
                {
                    map[hashstr] = new List<string>();
                }
                map[hashstr].Add(str);
            }

            return map.Values.ToList();
        }

        private string HashStr(string str)
        {

            int shift = str[0] - 'a';
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                char ch = (char)((str[i] - shift + 26) % 26 + 'a');

                sb.Append(ch);
            }

            return sb.ToString();
        }
    }
}
