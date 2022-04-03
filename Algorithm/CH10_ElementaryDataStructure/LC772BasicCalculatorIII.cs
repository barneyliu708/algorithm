using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC772BasicCalculatorIII
    {
        public int Calculate(string s)
        {
            Dictionary<char, Action<Stack<int>, int>> operations = new Dictionary<char, Action<Stack<int>, int>>() {
                { '+', (Stack<int> s, int operand) => { s.Push(operand); }},
                { '-', (Stack<int> s, int operand) => { s.Push(-operand); }},
                { '*', (Stack<int> s, int operand) => { s.Push(s.Pop() * operand); }},
                { '/', (Stack<int> s, int operand) => { s.Push(s.Pop() / operand); }}
            };
            int i = 0;
            return Calculate(s, operations, ref i);
        }

        private int Calculate(string s, Dictionary<char, Action<Stack<int>, int>> operations, ref int i)
        {
            Stack<int> stack = new Stack<int>();

            int operand = 0;
            char sign = '+'; // store the sign before the operand
            while (i < s.Length)
            {
                char ch = s[i];
                i++;

                if (char.IsDigit(ch))
                {
                    operand = operand * 10 + (ch - '0');
                }
                else if (ch == '(')
                {
                    operand = Calculate(s, operations, ref i);
                }
                else if (ch == ')')
                {
                    break;
                }
                else
                {
                    operations[sign](stack, operand);
                    sign = ch;
                    operand = 0;
                }
            }

            // push the last operand and its sign in the expression to the stack
            operations[sign](stack, operand);

            int ans = 0;
            while (stack.Count > 0)
            {
                ans += stack.Pop();
            }

            return ans;
        }
    }
}
