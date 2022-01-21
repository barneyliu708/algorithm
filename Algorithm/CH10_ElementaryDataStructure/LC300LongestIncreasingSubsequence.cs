using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC300LongestIncreasingSubsequence
    {
        public int LengthOfLIS(int[] nums)
        {

            int[] dp = new int[nums.Length];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = 1;
            }

            int ans = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                ans = Math.Max(ans, dp[i]);
            }

            return ans;
        }
    }
}
