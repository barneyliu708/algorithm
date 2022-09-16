using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    public class LC032LongestValidParentheses
    {
        public int LongestValidParentheses(string s)
        {

            int maxlen = 0;
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }
                else
                {
                    int preidx = stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        maxlen = Math.Max(maxlen, i - stack.Peek());
                    }
                }
            }
            return maxlen;
        }

        public class SecondDone
        {
            public int LongestValidParentheses(string s)
            {
                int ans = 0;
                Stack<int> stack = new Stack<int>();
                stack.Push(-1);
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(')
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        stack.Pop();
                        if (stack.Count == 0)
                        {
                            stack.Push(i);
                        }
                        else
                        {
                            ans = Math.Max(ans, i - stack.Peek());
                        }
                    }
                }

                return ans;
            }
        }
    }
}
