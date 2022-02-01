using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    public class LC291WordPatternII
    {
        public bool WordPatternMatch(string pattern, string s)
        {

            Dictionary<char, string> ptos = new Dictionary<char, string>();
            Dictionary<string, char> stop = new Dictionary<string, char>();

            return WordPatternMatch(pattern, 0, s, 0, ptos, stop);
        }

        private bool WordPatternMatch(string pattern, int p, string str, int l, Dictionary<char, string> ptos, Dictionary<string, char> stop)
        {

            if (p == pattern.Length && l == str.Length)
            {
                return true;
            }

            if (p == pattern.Length && l != str.Length)
            {
                return false;
            }

            for (int i = l; i < str.Length; i++)
            {

                char ch = pattern[p];
                string substr = str.Substring(l, i - l + 1);

                if (ptos.ContainsKey(ch) && ptos[ch] == substr)
                {
                    if (WordPatternMatch(pattern, p + 1, str, i + 1, ptos, stop))
                    {
                        return true;
                    }
                }
                else if (!ptos.ContainsKey(ch) && !stop.ContainsKey(substr))
                {
                    ptos[ch] = substr;
                    stop[substr] = ch;
                    if (WordPatternMatch(pattern, p + 1, str, i + 1, ptos, stop))
                    {
                        return true;
                    }
                    ptos.Remove(ch);
                    stop.Remove(substr);
                }
            }

            return false;
        }

        [Test]
        public void TestCase1()
        {
            string pattern = "abab";
            string s = "redblueredblue";

            var result = WordPatternMatch(pattern, s);
        }
    }
}
