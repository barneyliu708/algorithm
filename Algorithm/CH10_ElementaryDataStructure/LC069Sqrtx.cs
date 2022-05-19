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

        public class SecondDone
        {
            public int MySqrt(int x)
            {
                long l = 1;
                long r = x;
                while (l <= r)
                {
                    long mid = l + (r - l) / 2;
                    if (mid * mid == x)
                    {
                        return (int)mid;
                    }
                    else if (mid * mid > x)
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }

                return (int)r;
            }
        }
    }
}
