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

        public class SecondDone
        {
            public int MinFlipsMonoIncr(string s)
            {
                int n = s.Length;
                int[] zeros = new int[n];
                int[] ones = new int[n];

                int flips = 0;
                for (int i = 0; i < n; i++)
                {
                    if (s[i] == '1')
                    {
                        flips++;
                    }
                    zeros[i] = flips;
                }

                flips = 0;
                for (int i = n - 1; i >= 0; i--)
                {
                    if (s[i] == '0')
                    {
                        flips++;
                    }
                    ones[i] = flips;
                }

                int ans = ones[0];
                for (int i = 0; i < n; i++)
                {
                    if (i == n - 1)
                    {
                        ans = Math.Min(ans, zeros[i]);
                    }
                    else
                    {
                        ans = Math.Min(ans, zeros[i] + ones[i + 1]);
                    }
                }

                return ans;
            }
        }
    }
}
