using System;
using System.Collections.Generic;
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
    }
}
