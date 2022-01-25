using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC017LetterCombinationsOfAPhoneNumber
    {
        public IList<string> LetterCombinations(string digits)
        {
            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>() {
            { "2", new List<string>() {"a", "b", "c"} },
            { "3", new List<string>() {"d", "e", "f"} },
            { "4", new List<string>() {"g", "h", "i"} },
            { "5", new List<string>() {"j", "k", "l"} },
            { "6", new List<string>() {"m", "n", "o"} },
            { "7", new List<string>() {"p", "q", "r", "s"} },
            { "8", new List<string>() {"t", "u", "v"} },
            { "9", new List<string>() {"w", "x", "y", "z"} }
            };

            return LetterCombination(digits, 0, digits.Length - 1, map);
        }

        private IList<string> LetterCombination(string digits, int l, int r, Dictionary<string, IList<string>> map)
        {
            if (l > r)
            {
                return new List<string>();
            }

            string substr = digits.Substring(l, r - l + 1);
            if (map.ContainsKey(substr))
            {
                return map[substr];
            }

            int m = (l + r) / 2;
            IList<string> leftResults = LetterCombination(digits, l, m, map);
            IList<string> rightResults = LetterCombination(digits, m + 1, r, map);

            IList<string> ans = new List<string>();
            foreach (string left in leftResults)
            {
                foreach (string right in rightResults)
                {
                    ans.Add(left + right);
                }
            }

            map[substr] = ans;
            return ans;
        }
    }
}
