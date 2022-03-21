using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC007ReverseInteger
    {
        public int Reverse(int x)
        {

            if (x < 0)
            {
                if (x == int.MinValue)
                {
                    return 0;
                }
                return -1 * Reverse(-x);
            }

            int ans = 0;
            while (x > 0)
            {
                int lastdigit = x % 10;
                if (ans > (int.MaxValue - lastdigit) / 10)
                {
                    return 0;
                }
                ans = ans * 10 + lastdigit;
                x = x / 10;
            }
            return ans;
        }
    }
}
