using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC151ReverseWordsInAString
    {
        public string ReverseWords(string s)
        {
            StringBuilder sb = TrimSpaces(s);
            Reverse(sb, 0, sb.Length - 1);
            ReverseWords(sb);
            return sb.ToString();
        }

        public StringBuilder TrimSpaces(string s)
        {
            int l = 0;
            int r = s.Length - 1;

            // remove leading spaces
            while (l < s.Length && s[l] == ' ')
            {
                l++;
            }

            // remove trailing spaces
            while (r >= 0 && s[r] == ' ')
            {
                r--;
            }

            // remove multiple spaces to single space
            StringBuilder sb = new StringBuilder();
            while (l <= r)
            {
                char c = s[l];
                if (c != ' ')
                {
                    sb.Append(c);
                }
                else if (sb[sb.Length - 1] != ' ')
                {
                    sb.Append(c);
                }

                l++;
            }

            return sb;
        }

        public void Reverse(StringBuilder sb, int l, int r)
        {
            while (l < r)
            {
                char temp = sb[l];
                sb[l] = sb[r];
                sb[r] = temp;
                l++;
                r--;
            }
        }

        public void ReverseWords(StringBuilder sb)
        {
            int l = 0;
            int r = 0;

            while (l < sb.Length)
            {
                while (r < sb.Length && sb[r] != ' ')
                {
                    r++;
                }
                Reverse(sb, l, r - 1);
                l = r + 1;
                r++;
            }
        }
    }
}
