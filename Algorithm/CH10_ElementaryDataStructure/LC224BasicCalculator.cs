using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC224BasicCalculator
    {
        public int Calculate(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char ch in s)
            {
                if (ch != ' ') // remove space
                {
                    sb.Append(ch);
                }
            }
            int i = 0;
            return Calculate(sb.ToString(), ref i);
        }

        public int Calculate(string s, ref int i)
        {
            int operand = 0;
            int result = 0;
            int sign = 1;
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
                    operand = Calculate(s, ref i);
                }
                else if (ch == ')')
                {
                    break; // the sub-expression is ended, exit now
                }
                else // ch == operator
                {
                    // store the current calculation to the result
                    result += sign * operand;

                    // reset the sign the operand
                    sign = ch == '+' ? 1 : -1;
                    operand = 0;
                }
            }
            return result + sign * operand;
        }

        public class SecondDone
        {
            public int Calculate(string s)
            {

                if (s[0] == '-')
                {
                    s = '0' + s;
                }
                Stack<int> stack = new Stack<int>();
                Stack<int> signs = new Stack<int>();
                stack.Push(0);
                signs.Push(1);
                int curSign = 1;
                int curNum = 0;
                foreach (char ch in s)
                {
                    if (ch == ' ')
                    {
                        continue;
                    }
                    if (ch == '+' || ch == '-')
                    {
                        int curSum = stack.Pop();
                        curSum += curSign * curNum;
                        stack.Push(curSum);

                        // reset curNum and curSign
                        curNum = 0;
                        curSign = ch == '+' ? 1 : -1;
                    }
                    else if (ch == '(')
                    {
                        stack.Push(0);
                        signs.Push(curSign);

                        // reset the curSign for the next level
                        curSign = 1;
                    }
                    else if (ch == ')')
                    {
                        int curSum = stack.Pop();
                        curSum += curSign * curNum;

                        // pop up to the parent level
                        curNum = curSum;
                        curSign = signs.Pop();
                    }
                    else
                    { // digits
                        curNum = curNum * 10 + (ch - '0');
                    }
                }

                return stack.Pop() + curSign * curNum;
            }
        }
    }
}
