using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC259_3SumSmaller
    {
        public int ThreeSumSmaller(int[] nums, int target)
        {

            Array.Sort(nums);
            int sum = 0;
            for (int i = 0; i < nums.Length - 2; i++)
            {
                sum += TwoSumSmaller(nums, i + 1, target - nums[i]);
            }
            return sum;
        }

        public int TwoSumSmaller(int[] nums, int start, int target)
        {
            int sum = 0;
            int end = nums.Length - 1;
            while (start < end)
            {
                if (nums[start] + nums[end] < target)
                {
                    sum += end - start;
                    start++;
                }
                else
                {
                    end--;
                }
            }
            return sum;
        }
    }
}
