using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC050PowX_N
    {
        public double MyPow(double x, int n)
        {

            return FastPow(x, n);
        }

        private double FastPow(double x, long n)
        {
            if (n == 0)
            {
                return 1.0;
            }

            if (n < 0)
            {
                x = 1 / x;
                n = -n; // may overflow, so need to convert from int to long

                return FastPow(x, n);
            }

            double half = FastPow(x, n / 2);
            if (n % 2 == 0)
            {
                return half * half;
            }

            return half * half * x;
        }
    }
}
