using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC069Sqrtx
    {
        public int MySqrt(int x)
        {

            int start = 0, end = x / 2 + 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                long sqr = (long)mid * mid;
                if (sqr == x)
                {
                    return mid;
                }
                else if (sqr > x)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return end;
        }
    }
}
