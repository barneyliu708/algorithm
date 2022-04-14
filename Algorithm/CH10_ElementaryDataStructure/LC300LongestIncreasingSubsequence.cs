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

        public class TopDown_DP
        {
            public int LengthOfLIS(int[] nums)
            {
                Dictionary<int, int> memo = new Dictionary<int, int>();
                int ans = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    ans = Math.Max(ans, LengthOfLIS(nums, i, memo));
                }
                return ans;
            }

            private int LengthOfLIS(int[] nums, int i, Dictionary<int, int> memo)
            {
                if (i == 0)
                {
                    memo[0] = 1;
                    return 1;
                }
                if (memo.ContainsKey(i))
                {
                    return memo[i];
                }

                int ans = 1;
                for (int j = 0; j < i; j++)
                {
                    if (nums[j] < nums[i])
                    {
                        ans = Math.Max(ans, LengthOfLIS(nums, j, memo) + 1);
                    }
                }

                memo[i] = ans;
                return memo[i];
            }
        }
    }
}
