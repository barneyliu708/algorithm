using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC239SlidingWindowMaximum
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {

            if (k == 1)
            {
                return nums;
            }

            int n = nums.Length;
            int[] lmax = new int[n];
            int[] rmax = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (i % k == 0)
                {
                    lmax[i] = nums[i];
                }
                else
                {
                    lmax[i] = Math.Max(lmax[i - 1], nums[i]);
                }
            }
            for (int i = n - 1; i >= 0; i--)
            {
                if (i == n - 1 || (i + 1) % k == 0)
                {
                    rmax[i] = nums[i];
                }
                else
                {
                    rmax[i] = Math.Max(rmax[i + 1], nums[i]);
                }
            }

            int[] ans = new int[n - k + 1];
            for (int i = 0; i < n - k + 1; i++)
            {
                ans[i] = Math.Max(lmax[i + k - 1], rmax[i]);
            }

            return ans;
        }
    }
}
