using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    internal class LC009PalindromeNumber
    {
        public bool IsPalindrome(int x)
        {
            if (x < 0 || (x % 10 == 0 && x != 0))
            {
                return false;
            }

            int revert = 0;
            while (x > revert)
            {
                revert = revert * 10 + x % 10;
                x /= 10;
            }

            return x == revert || x == revert / 10;
        }
    }
}
