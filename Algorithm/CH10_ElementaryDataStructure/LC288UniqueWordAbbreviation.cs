using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC288UniqueWordAbbreviation
    {
        public class ValidWordAbbr
        {

            private Dictionary<string, HashSet<string>> map;

            public ValidWordAbbr(string[] dictionary)
            {
                map = new Dictionary<string, HashSet<string>>();

                foreach (string word in dictionary)
                {
                    string abbreviation = Abbreviate(word);
                    if (!map.ContainsKey(abbreviation))
                    {
                        map[abbreviation] = new HashSet<string>();
                    }
                    map[abbreviation].Add(word);
                }

            }

            public bool IsUnique(string word)
            {
                string abbreviation = Abbreviate(word);
                if (!map.ContainsKey(abbreviation))
                {
                    return true;
                }
                return map[abbreviation].Count == 1 && map[abbreviation].Contains(word);
            }

            private string Abbreviate(string word)
            {
                if (word.Length <= 2)
                {
                    return word;
                }

                StringBuilder sb = new StringBuilder();
                sb.Append(word[0]);
                sb.Append((word.Length - 2).ToString());
                sb.Append(word[word.Length - 1]);

                return sb.ToString();
            }
        }

    }
}
