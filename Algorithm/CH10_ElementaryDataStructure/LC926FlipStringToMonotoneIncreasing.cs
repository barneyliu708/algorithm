using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC926FlipStringToMonotoneIncreasing
    {
        public int MinFlipsMonoIncr(string s)
        {
            int n = s.Length;

            int[] presum = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                presum[i + 1] = presum[i] + (s[i] - '0');
            }

            int ans = int.MaxValue;
            for (int i = 0; i <= n; i++)
            {
                ans = Math.Min(ans, presum[i] + n - i - (presum[n] - presum[i]));
            }

            return ans;
        }
    }
}
