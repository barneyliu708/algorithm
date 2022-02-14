using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC367ValidPerfectSquare
    {
        public bool IsPerfectSquare(int num)
        {

            if (num == 1 || num == 4 || num == 9 || num == 16)
            {
                return true;
            }

            int lo = 0;
            int hi = num / 4;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                long sqr = (long)mid * mid;
                if (sqr == num)
                {
                    return true;
                }
                else if (sqr < num)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return false;
        }
    }
}
