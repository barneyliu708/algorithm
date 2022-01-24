using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC012IntegerToRoman
    {
        public string IntToRoman(int num)
        {

            int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] symbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            StringBuilder sb = new StringBuilder();

            while (num > 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    while (num >= values[i])
                    {
                        num -= values[i];
                        sb.Append(symbols[i]);
                    }
                }
            }

            return sb.ToString();
        }
    }
}
