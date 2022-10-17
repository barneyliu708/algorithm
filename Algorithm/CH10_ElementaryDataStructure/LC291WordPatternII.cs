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

        public class SecondDone
        {
            public bool WordPatternMatch(string pattern, string str)
            {
                Dictionary<char, string> ptos = new Dictionary<char, string>();
                Dictionary<string, char> stop = new Dictionary<string, char>();
                return Backtracking(pattern, 0, str, 0, ptos, stop);
            }

            private bool Backtracking(string pattern, int pi, string str, int si, Dictionary<char, string> ptos, Dictionary<string, char> stop)
            {

                if (pi == pattern.Length && si == str.Length)
                {
                    return true;
                }

                if (pi == pattern.Length || si == str.Length)
                {
                    return false;
                }

                for (int i = si; i < str.Length; i++)
                {
                    char pch = pattern[pi];
                    string substr = str.Substring(si, i - si + 1);
                    if (ptos.ContainsKey(pch) && ptos[pch] == substr)
                    {
                        if (Backtracking(pattern, pi + 1, str, i + 1, ptos, stop))
                        {
                            return true;
                        }
                    }
                    else if (!ptos.ContainsKey(pch) && !stop.ContainsKey(substr))
                    {
                        ptos[pch] = substr;
                        stop[substr] = pch;
                        if (Backtracking(pattern, pi + 1, str, i + 1, ptos, stop))
                        {
                            return true;
                        }
                        ptos.Remove(pch);
                        stop.Remove(substr);
                    }
                }

                return false;
            }
        }

        public class ThirdDone
        {
            public bool WordPatternMatch(string pattern, string s)
            {
                Dictionary<char, string> ptos = new Dictionary<char, string>();
                Dictionary<string, char> stop = new Dictionary<string, char>();
                return IsMatch(pattern, s, 0, 0, ptos, stop);
            }

            private bool IsMatch(string pattern, string s, int pi, int si, Dictionary<char, string> ptos, Dictionary<string, char> stop)
            {

                if (pi == pattern.Length && si == s.Length)
                {
                    return true;
                }

                if (pi == pattern.Length || si == s.Length)
                {
                    return false;
                }

                for (int i = si; i < s.Length; i++)
                {

                    char p = pattern[pi];
                    string str = s.Substring(si, i - si + 1);

                    if (!ptos.ContainsKey(p) && !stop.ContainsKey(str))
                    {
                        ptos[p] = str;
                        stop[str] = p;
                        if (IsMatch(pattern, s, pi + 1, i + 1, ptos, stop))
                        {
                            return true;
                        }
                        ptos.Remove(p);
                        stop.Remove(str);
                    }
                    else if (ptos.ContainsKey(p) && stop.ContainsKey(str) && ptos[p] == str && stop[str] == p)
                    {
                        if (IsMatch(pattern, s, pi + 1, i + 1, ptos, stop))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        public class ForthDone
        {
            public bool WordPatternMatch(string pattern, string s)
            {
                Dictionary<char, string> ptos = new Dictionary<char, string>();
                Dictionary<string, char> stop = new Dictionary<string, char>();
                return Utility(pattern, 0, s, 0, ptos, stop);
            }

            private bool Utility(string pattern, int pi, string s, int si, Dictionary<char, string> ptos, Dictionary<string, char> stop)
            {
                if (pi == pattern.Length && si == s.Length)
                {
                    return true;
                }
                if (pi == pattern.Length || si == s.Length)
                {
                    return false;
                }
                char curp = pattern[pi];
                for (int i = si; i < s.Length; i++)
                {
                    string curs = s.Substring(si, i - si + 1);
                    if ((ptos.ContainsKey(curp) && ptos[curp] != curs) ||
                        (stop.ContainsKey(curs) && stop[curs] != curp))
                    {
                        continue;
                    }
                    else if (ptos.ContainsKey(curp) && stop.ContainsKey(curs) && ptos[curp] == curs && stop[curs] == curp)
                    {
                        if (Utility(pattern, pi + 1, s, i + 1, ptos, stop))
                        {
                            return true;
                        }
                    }
                    else if (!ptos.ContainsKey(curp) && !stop.ContainsKey(curs))
                    {
                        ptos[curp] = curs;
                        stop[curs] = curp;
                        if (Utility(pattern, pi + 1, s, i + 1, ptos, stop))
                        {
                            return true;
                        }
                        ptos.Remove(curp);
                        stop.Remove(curs);
                    }
                }
                return false;
            }
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
