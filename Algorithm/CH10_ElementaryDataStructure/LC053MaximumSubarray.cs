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
    }
}
