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
    }
}
