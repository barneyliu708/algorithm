using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC053MaximumSubarray
    {
        public int MaxSubArray(int[] nums)
        {

            int curMax = nums[0];
            int totalMax = nums[0];

            for (int i = 1; i < nums.Length; i++)
            {
                int num = nums[i];
                curMax = Math.Max(num, curMax + num);
                totalMax = Math.Max(curMax, totalMax);
            }

            return totalMax;
        }

        public class SecondDone
        {
            public int MaxSubArray(int[] nums)
            {
                int n = nums.Length;
                int[] presum = new int[n + 1];
                for (int i = 1; i < n + 1; i++)
                {
                    presum[i] = presum[i - 1] + nums[i - 1];
                }

                int max = int.MinValue;
                int l = 0;
                int r = 1; // need at least one element
                while (r < n + 1)
                {
                    int subsum = presum[r] - presum[l];
                    max = Math.Max(max, subsum);
                    if (subsum < 0)
                    {
                        l = r;
                    }
                    r++;
                }

                return max;
            }
        }
    }
}
