using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC227BasicCalculatorII
    {
        public int Calculate(string s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }

            Stack<int> stack = new Stack<int>();
            int curNum = 0;
            char operation = '+';
            for (int i = 0; i < s.Length; i++)
            {
                char ch = s[i];
                if (Char.IsDigit(ch))
                {
                    curNum = curNum * 10 + (ch - '0');
                }
                if (IsOperation(ch) || i == s.Length - 1)
                {
                    // need to check the operation before the current number, eg + 15 *, it need to check + rather than *
                    if (operation == '+') 
                    {
                        stack.Push(curNum);
                    }
                    else if (operation == '-')
                    {
                        stack.Push(-curNum);
                    }
                    else if (operation == '*')
                    {
                        stack.Push(stack.Pop() * curNum);
                    }
                    else if (operation == '/')
                    {
                        stack.Push(stack.Pop() / curNum);
                    }
                    operation = ch;
                    curNum = 0;
                }
            }

            int ans = 0;
            while (stack.Count > 0)
            {
                ans += stack.Pop();
            }
            return ans;
        }

        private bool IsOperation(char ch)
        {
            return ch == '+' || ch == '-' || ch == '*' || ch == '/';
        }
    }
}
