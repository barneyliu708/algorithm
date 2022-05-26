using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC166FractionToRecurringDecimal
    {
        public string FractionToDecimal(int numerator, int denominator)
        {

            if (numerator == 0)
            {
                return "0";
            }

            StringBuilder sb = new StringBuilder();

            if (numerator < 0 ^ denominator < 0)
            {
                sb.Append("-");
            }
            long dividend = Math.Abs((long)numerator);
            long dividor = Math.Abs((long)denominator);
            sb.Append((dividend / dividor).ToString());

            long remainder = dividend % dividor;
            if (remainder == 0)
            {
                return sb.ToString();
            }

            sb.Append(".");
            Dictionary<long, int> map = new Dictionary<long, int>();
            while (remainder != 0)
            {
                if (map.ContainsKey(remainder))
                {
                    sb.Insert(map[remainder], "(");
                    sb.Append(")");
                    break;
                }

                map[remainder] = sb.Length;
                remainder *= 10;
                sb.Append((remainder / dividor).ToString());
                remainder = remainder % dividor;
            }

            return sb.ToString();
        }

        public string FractionToDecimal(int numerator, int denominator)
        {

            if (numerator == 0)
            {
                return "0";
            }

            StringBuilder sb = new StringBuilder();

            if (numerator < 0 ^ denominator < 0)
            {
                sb.Append('-');
            }

            long dividend = Math.Abs((long)numerator);
            long dividor = Math.Abs((long)denominator);

            sb.Append((dividend / dividor).ToString());
            dividend = dividend % dividor;

            if (dividend == 0)
            {
                return sb.ToString();
            }

            sb.Append('.');
            Dictionary<long, int> map = new Dictionary<long, int>(); // remainder - sb length
            while (dividend != 0)
            {
                if (map.ContainsKey(dividend))
                {
                    sb.Insert(map[dividend], '(');
                    sb.Append(')');
                    break;
                }
                map[dividend] = sb.Length;
                dividend *= 10;
                sb.Append((dividend / dividor).ToString());
                dividend = dividend % dividor;
            }

            return sb.ToString();
        }
    }
}
