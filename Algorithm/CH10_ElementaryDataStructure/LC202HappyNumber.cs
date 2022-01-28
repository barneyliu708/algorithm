using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC202HappyNumber
    {
        public bool IsHappy(int n)
        {

            if (n < 0)
            {
                return false;
            }

            return IsHappy(n, new HashSet<int>());
        }

        private bool IsHappy(int n, HashSet<int> hashset)
        {

            int sum = 0;
            while (n != 0)
            {
                int remainder = n % 10;
                sum += remainder * remainder;
                n = n / 10;
            }

            if (sum == 1)
            {
                return true;
            }

            if (hashset.Contains(sum))
            {
                return false;
            }

            hashset.Add(sum);

            return IsHappy(sum, hashset);
        }
    }
}
