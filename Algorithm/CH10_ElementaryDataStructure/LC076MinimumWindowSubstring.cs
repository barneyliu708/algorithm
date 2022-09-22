using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC076MinimumWindowSubstring
    {
        public string MinWindow(string s, string t)
        {

            Dictionary<char, int> target = new Dictionary<char, int>();
            foreach (char ch in t)
            {
                if (!target.ContainsKey(ch))
                {
                    target[ch] = 0;
                }
                target[ch]++;
            }

            Dictionary<char, int> window = new Dictionary<char, int>();
            int formed = 0;
            (int len, int l, int r) ans = (-1, 0, 0);
            int l = 0;
            int r = 0;
            while (r < s.Length)
            {
                char rch = s[r];
                if (!window.ContainsKey(rch))
                {
                    window[rch] = 0;
                }
                window[rch]++;

                if (target.ContainsKey(rch) && target[rch] == window[rch])
                {
                    formed++;
                }

                while (l <= r && formed == target.Keys.Count)
                {
                    char lch = s[l];
                    if (ans.len == -1 || r - l + 1 < ans.len)
                    {
                        ans.len = r - l + 1;
                        ans.l = l;
                        ans.r = r;
                    }

                    // remove lch from current window
                    window[lch]--;
                    if (target.ContainsKey(lch) && target[lch] > window[lch])
                    {
                        formed--;
                    }

                    l++;
                }

                r++;
            }

            return ans.len == -1 ? "" : s.Substring(ans.l, ans.len);
        }

        public class SecondDone
        {
            public string MinWindow(string s, string t)
            {

                // count the characters in the t string
                Dictionary<char, int> tmap = new Dictionary<char, int>();
                foreach (char ch in t)
                {
                    if (!tmap.ContainsKey(ch))
                    {
                        tmap[ch] = 0;
                    }
                    tmap[ch]++;
                }

                // sliding window
                int l = 0;
                int r = 0;
                Dictionary<char, int> smap = new Dictionary<char, int>(); // count the characters in the sliding window of s string
                HashSet<char> goodChars = new HashSet<char>(); // good characters that satisfy the required condition
                (int startIndex, int length) ans = (-1, s.Length);
                while (r < s.Length)
                {
                    char rch = s[r];
                    if (!smap.ContainsKey(rch))
                    {
                        smap[rch] = 0;
                    }
                    smap[rch]++;

                    // check if rch is good enough
                    if (tmap.ContainsKey(rch) && smap[rch] >= tmap[rch])
                    {
                        goodChars.Add(rch);
                    }

                    // check if need to shrink the sliding window
                    while (l <= r && goodChars.Count == tmap.Keys.Count)
                    {

                        // store the current answer
                        if (r - l + 1 <= ans.length)
                        {
                            ans.startIndex = l;
                            ans.length = r - l + 1;
                        }

                        // shrink the window at left side
                        char lch = s[l];
                        smap[lch]--;
                        if (tmap.ContainsKey(lch) && smap[lch] < tmap[lch])
                        {
                            goodChars.Remove(lch);
                        }
                        l++;
                    }

                    r++;
                }

                if (ans.startIndex == -1)
                {
                    return "";
                }

                return s.Substring(ans.startIndex, ans.length);
            }
        }

        public class ThirdDone
        {
            public string MinWindow(string s, string t)
            {
                Dictionary<char, int> tcnt = new Dictionary<char, int>();
                foreach (char ch in t)
                {
                    if (!tcnt.ContainsKey(ch))
                    {
                        tcnt[ch] = 0;
                    }
                    tcnt[ch]++;
                }

                int l = 0;
                int r = 0;
                Dictionary<char, int> scnt = new Dictionary<char, int>();
                int meet = 0;
                int len = s.Length;
                int i = 0;
                bool ismeet = false;
                while (r < s.Length)
                {
                    char rch = s[r];
                    if (!scnt.ContainsKey(rch))
                    {
                        scnt[rch] = 0;
                    }
                    scnt[rch]++;
                    if (tcnt.ContainsKey(rch) && scnt[rch] == tcnt[rch])
                    {
                        meet++;
                    }

                    while (meet == tcnt.Count)
                    {
                        ismeet = true;
                        if (r - l + 1 < len)
                        {
                            len = r - l + 1;
                            i = l;
                        }

                        char lch = s[l];
                        scnt[lch]--;
                        if (tcnt.ContainsKey(lch) && scnt[lch] < tcnt[lch])
                        {
                            meet--;
                        }
                        l++;
                    }

                    r++;
                }

                return ismeet ? s.Substring(i, len) : "";
            }
        }
    }
}
