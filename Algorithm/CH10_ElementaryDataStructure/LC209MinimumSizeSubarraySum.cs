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

        public class StandardSlidingWindowApproach
        {
            public int MinSubArrayLen(int target, int[] nums)
            {
                int[] presum = new int[nums.Length + 1];
                for (int i = 0; i < nums.Length; i++)
                {
                    presum[i + 1] = presum[i] + nums[i];
                }

                int l = 0;
                int r = 0;
                int ans = int.MaxValue;
                while (r < nums.Length)
                {
                    // get current state of the sliding window
                    int sum = presum[r] + nums[r] - presum[l]; // or int sum = presum[r + 1] - presum[l];

                    // chech if the current substring satisfy the target condition
                    while (sum >= target)
                    {
                        ans = Math.Min(ans, r - l + 1);
                        //l++;
                        //sum = presum[r] + nums[r] - presum[l];
                        sum -= nums[l++];
                    }

                    r++;
                }

                return ans == int.MaxValue ? 0 : ans;
            }

            public int MinSubArrayLen2(int target, int[] nums)
            {
                int sum = 0;
                int l = 0;
                int r = 0;
                int ans = int.MaxValue;
                while (r < nums.Length)
                {
                    // get current state of the sliding window
                    sum += nums[r];

                    // chech if the current substring sati
                    while (sum >= target)
                    {
                        ans = Math.Min(ans, r - l + 1);
                        sum -= nums[l++];
                    }

                    r++;
                }

                return ans == int.MaxValue ? 0 : ans;
            }
        }
    }
}
