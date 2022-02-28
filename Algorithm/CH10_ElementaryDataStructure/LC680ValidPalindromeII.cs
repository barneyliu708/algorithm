using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC680ValidPalindromeII
    {
        public bool ValidPalindrome(string s)
        {

            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return IsValid(s, left + 1, right) || IsValid(s, left, right - 1);
                }
                left++;
                right--;
            }
            return true;
        }

        private bool IsValid(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
}
