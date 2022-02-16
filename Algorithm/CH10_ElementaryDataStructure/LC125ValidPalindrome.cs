using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC125ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {

            int l = 0;
            int r = s.Length - 1;

            while (l < r)
            {
                while (l < r && !Char.IsLetterOrDigit(s[l]))
                {
                    l++;
                }
                while (l < r && !Char.IsLetterOrDigit(s[r]))
                {
                    r--;
                }
                if (Char.ToLower(s[l]) != Char.ToLower(s[r]))
                {
                    return false;
                }
                l++;
                r--;
            }

            return true;
        }
    }
}
