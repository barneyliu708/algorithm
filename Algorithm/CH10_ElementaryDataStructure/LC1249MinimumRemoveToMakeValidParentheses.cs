using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC1249MinimumRemoveToMakeValidParentheses
    {
        public string MinRemoveToMakeValid(string s)
        {

            Stack<int> stack = new Stack<int>();
            HashSet<int> indexesToRemoved = new HashSet<int>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else if (s[i] == ')')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        indexesToRemoved.Add(i);
                    }
                }
            }

            while (stack.Count != 0)
            {
                indexesToRemoved.Add(stack.Pop());
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (!indexesToRemoved.Contains(i))
                {
                    sb.Append(s[i]);
                }
            }

            return sb.ToString();
        }
    }
}
