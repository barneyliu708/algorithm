using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC209MinimumSizeSubarraySum
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            int[] presum = new int[nums.Length + 1];

            for (int i = 1; i < presum.Length; i++)
            {
                presum[i] = presum[i - 1] + nums[i - 1];
            }

            int start = 0;
            int end = 1;
            int minlen = int.MaxValue;
            while (start < end)
            {
                int subsum = presum[end] - presum[start];
                if (subsum < target)
                {
                    end++;
                    if (end >= presum.Length)
                    {
                        break;
                    }
                }
                else
                {
                    minlen = Math.Min(minlen, end - start);
                    start++;
                }
            }

            return minlen == int.MaxValue ? 0 : minlen;
        }
    }
}
