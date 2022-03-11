using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC856ScoreOfParentheses
    {
        public int ScoreOfParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            foreach (char ch in s)
            {
                if (ch == '(')
                {
                    stack.Push(0);
                }
                else
                {
                    int v = stack.Pop();
                    int w = stack.Pop();
                    stack.Push(w + Math.Max(2 * v, 1));
                }
            }

            return stack.Pop();
        }
    }
}
