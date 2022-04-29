﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1087BraceExpansion
    {
        public string[] Expand(string s)
        {

            List<string> ans = new List<string>();
            ans.Add("");
            for (int i = 0; i < s.Length; i++)
            {
                List<string> list = new List<string>();
                if (s[i] == '{')
                {
                    int start = i;
                    while (s[i] != '}')
                    {
                        i++;
                    }
                    string substr = s.Substring(start + 1, (i - 1) - (start + 1) + 1);
                    // Console.WriteLine(substr);
                    list = substr.Split(',').ToList();
                }
                else
                {
                    list.Add(s[i].ToString());
                }
                list.Sort();
                ans = CrossMultiply(ans, list);
            }

            return ans.ToArray();
        }

        private List<string> CrossMultiply(List<string> left, List<string> right)
        {
            List<string> ans = new List<string>();
            for (int i = 0; i < left.Count; i++)
            {
                for (int j = 0; j < right.Count; j++)
                {
                    // Console.WriteLine(left[i] + "-" + right[j]);
                    ans.Add(left[i] + right[j]);
                }
            }
            return ans;
        }

        public class SecondDone
        {
            public string[] Expand(string s)
            {
                List<string> ans = new List<string>() { "" };
                for (int i = 0; i < s.Length; i++)
                {
                    List<string> options = new List<string>();
                    if (s[i] == '{')
                    {
                        int li = i + 1;
                        while (s[i] != '}')
                        {
                            i++;
                        }
                        options = s.Substring(li, i - li).Split(',').ToList();
                    }
                    else
                    {
                        options.Add(s[i].ToString());
                    }
                    ans = CrossMultiple(ans, options);
                }
                ans.Sort();
                return ans.ToArray();
            }
            public List<string> CrossMultiple(List<string> left, List<string> right)
            {
                List<string> ans = new List<string>();
                foreach (string l in left)
                {
                    foreach (string r in right)
                    {
                        ans.Add(l + r);
                    }
                }
                return ans;
            }
        }
    }
}
