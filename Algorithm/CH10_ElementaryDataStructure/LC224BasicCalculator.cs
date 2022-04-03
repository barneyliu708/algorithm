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
    }
}
