using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC190ReverseBits
    {
        public uint reverseBits(uint n)
        {

            uint ans = 0;
            int power = 31;

            while (n != 0)
            {
                ans += (n & 1) << power;
                n = n >> 1;
                power--;
            }

            return ans;
        }
    }
}
