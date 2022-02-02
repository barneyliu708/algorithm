using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC372SuperPow
    {
        public int SuperPow(int a, int[] b)
        {

            int ans = 1;
            for (int i = 0; i < b.Length; i++)
            {
                ans = Pow(ans, 10) * Pow(a, b[i]) % 1337;
            }

            return ans;
        }

        private int Pow(int x, int n)
        {

            if (n == 0)
            {
                return 1;
            }

            if (n == 1)
            {
                return x % 1337;
            }

            return Pow(x % 1337, n / 2) * Pow(x % 1337, n - n / 2) % 1337;
        }
    }
}
