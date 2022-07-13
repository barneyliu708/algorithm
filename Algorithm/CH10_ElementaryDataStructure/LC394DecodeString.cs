using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC394DecodeString
    {
        public string DecodeString(string s)
        {

            Stack<int> countStack = new Stack<int>();
            Stack<StringBuilder> stringStack = new Stack<StringBuilder>();
            StringBuilder currentString = new StringBuilder();
            int k = 0;

            foreach (char ch in s)
            {
                if (ch >= '0' && ch <= '9')
                {
                    k = k * 10 + (ch - '0');
                }
                else if (ch == '[')
                {
                    countStack.Push(k);
                    stringStack.Push(currentString);

                    // reset
                    currentString = new StringBuilder();
                    k = 0;
                }
                else if (ch == ']')
                {
                    StringBuilder decodedString = stringStack.Pop();
                    // decode currentK[currentString] by appending currentString k times
                    for (int currentK = countStack.Pop(); currentK > 0; currentK--)
                    {
                        decodedString.Append(currentString);
                    }
                    currentString = decodedString;
                }
                else
                {
                    currentString.Append(ch);
                }
            }

            return currentString.ToString();
        }

        public class SecondDone
        {
            public string DecodeString(string s)
            {
                int i = 0;
                return DecodeString(s, ref i);
            }

            private string DecodeString(string s, ref int i)
            {
                int digit = 0;
                StringBuilder sb = new StringBuilder();
                for (; i < s.Length; i++)
                {
                    char ch = s[i];
                    if (char.IsDigit(ch))
                    {
                        digit = digit * 10 + (ch - '0');
                    }
                    else if (ch == '[')
                    {
                        i++;
                        string nestedStr = DecodeString(s, ref i);
                        sb.Append(string.Concat(Enumerable.Repeat(nestedStr, digit)));
                        digit = 0;
                    }
                    else if (ch == ']')
                    {
                        break;
                    }
                    else
                    {
                        sb.Append(ch);
                    }
                }
                return sb.ToString();
            }
        }
    }
}
