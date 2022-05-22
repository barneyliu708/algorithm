using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
    public class LC045JumpGameII
    {
        public int Jump(int[] nums)
        {
            int[] dp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                dp[i] = int.MaxValue;
            }

            dp[dp.Length - 1] = 0; // the last position can always take 0 step to the end

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                int maxJump = Math.Min(i + nums[i], nums.Length - 1);

                int minSteps = nums.Length; // use nums.Length rather that int.MaxValue as the default minsteps to void overflow if the maxJump at i is 0;
                for (int j = i + 1; j <= maxJump; j++)
                {
                    if (dp[j] < minSteps)
                    {
                        minSteps = dp[j];
                    }
                }
                dp[i] = minSteps + 1;

            }

            return dp[0];
        }

        public class SecondDone
        {
            public int Jump(int[] nums)
            {
                int[] dp = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    dp[i] = int.MaxValue;
                }
                dp[0] = 0; // it only takes 0 step to reach to the 0th position
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 1; j <= nums[i] && i + j < nums.Length; j++)
                    {
                        dp[i + j] = Math.Min(dp[i + j], dp[i] + 1);
                    }
                }

                return dp[nums.Length - 1];
            }
        }

        [Test]
        public void TestJump()
        {
            int[] nums = new int[] { 2, 3, 1, 1, 4 };
            var test = Jump(nums);
        }
    }
}
