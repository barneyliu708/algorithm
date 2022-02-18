using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC374GuessNumberHigherOrLower
    {
        int guess (int guess)
        {
            return 0;
        }
        public int GuessNumber(int n)
        {
            int hi = n;
            int lo = 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (guess(mid) == 0)
                {
                    return mid;
                }
                else if (guess(mid) == 1)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }

            return 0;
        }
    }
}
