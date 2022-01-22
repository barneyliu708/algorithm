using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC338CountingBits
    {
        public int[] CountBits(int n)
        {

            int[] ans = new int[n + 1];
            for (int x = 1; x <= n; x++)
            {
                // x / 2 is x >> 1, and x % 2 is x & 1
                ans[x] = ans[x >> 1] + (x & 1);
            }

            return ans;
        }
    }
}
