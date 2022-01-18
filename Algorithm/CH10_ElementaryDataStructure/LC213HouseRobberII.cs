using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC213HouseRobberII
    {
        public int Rob(int[] nums)
        {

            if (nums.Length == 0)
            {
                return 0;
            }

            if (nums.Length == 1)
            {
                return nums[0];
            }

            return Math.Max(Rob(nums, 0, nums.Length - 2), Rob(nums, 1, nums.Length - 1));
        }

        private int Rob(int[] nums, int start, int end)
        {
            int t1 = 0;
            int t2 = 0;

            for (int i = start; i <= end; i++)
            {

                int temp = t1;
                int current = nums[i];
                t1 = Math.Max(current + t2, t1);
                t2 = temp;
            }

            return t1;
        }
    }
}
