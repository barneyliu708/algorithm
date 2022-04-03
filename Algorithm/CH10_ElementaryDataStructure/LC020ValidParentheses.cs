using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    public class LC020ValidParentheses
    {
        public bool IsValid(string s)
        {

            Dictionary<char, char> maps = new Dictionary<char, char>() {
                { ')', '(' },
                { ']', '[' },
                { '}', '{' }
            };

            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {

                char c = s[i];

                // if c is a closing bracket
                if (maps.ContainsKey(c))
                {
                    char topChart = stack.Count == 0 ? '#' : stack.Pop();
                    if (topChart != maps[c])
                    {
                        return false;
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            // if stack still contains elements, then it is an invalid expression
            return stack.Count == 0;
        }

        public class SecondDone
        {
            public bool IsValid(string s)
            {
                Stack<char> stack = new Stack<char>();
                Dictionary<char, char> map = new Dictionary<char, char>() {
                    { '(', ')' },
                    { '{', '}' },
                    { '[', ']' }
                };
                foreach (char ch in s)
                {
                    if (map.ContainsKey(ch))
                    {
                        stack.Push(ch);
                        continue;
                    }
                    if (stack.Count == 0 || map[stack.Pop()] != ch)
                    {
                        return false;
                    }
                }

                return stack.Count == 0;
            }
        }
    }
}
