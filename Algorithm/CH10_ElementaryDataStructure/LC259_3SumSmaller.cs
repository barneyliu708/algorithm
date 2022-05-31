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

        public class SecondDone
        {
            public int ThreeSumSmaller(int[] nums, int target)
            {
                Array.Sort(nums);
                int cnt = 0;
                for (int i = 0; i < nums.Length - 2; i++)
                {
                    cnt += TwoSumSmaller(nums, i + 1, target - nums[i]);
                }
                return cnt;
            }

            private int TwoSumSmaller(int[] nums, int istart, int target)
            {
                int l = istart;
                int r = nums.Length - 1;
                int cnt = 0;
                while (l < r)
                {
                    if (nums[l] + nums[r] < target)
                    {
                        cnt += r - l;
                        l++;
                    }
                    else
                    {
                        r--;
                    }
                }
                return cnt;
            }
        }
    }
}
