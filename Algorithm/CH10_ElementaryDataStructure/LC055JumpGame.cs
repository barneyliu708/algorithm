using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC055JumpGame
    {
        public class BacktrackingMethod
        {
            public bool CanJump(int[] nums)
            {
                return backtracking(0, nums);
            }

            private bool backtracking(int position, int[] nums)
            {
                if (position == nums.Length - 1)
                {
                    return true;
                }

                int maxJump = Math.Min(position + nums[position], nums.Length - 1);
                for (int nextPosition = position + 1; nextPosition <= maxJump; nextPosition++)
                {
                    if (backtracking(nextPosition, nums))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public class DynamicProgrammingTopDownMethod
        {
            private int UNKNOWN = 0;
            private int BAD = -1;
            private int GOOD = 1;

            public bool CanJump(int[] nums)
            {
                int[] dp = new int[nums.Length];
                dp[dp.Length - 1] = GOOD; // the last position can always reach out to itself
                return backtracking(0, nums, dp);
            }

            private bool backtracking(int position, int[] nums, int[] dp)
            {
                if (dp[position] != UNKNOWN)
                {
                    return dp[position] == GOOD;
                }

                int maxJump = Math.Min(position + nums[position], nums.Length - 1);
                for (int nextPosition = maxJump; nextPosition > position; nextPosition--)
                {
                    if (backtracking(nextPosition, nums, dp))
                    {
                        dp[position] = GOOD;
                        return true;
                    }
                }

                dp[position] = BAD;
                return false;
            }
        }

        public class DynamicProgrammingBottomUpMethod
        {
            private int UNKNOWN = 0;
            private int BAD = -1;
            private int GOOD = 1;

            public bool CanJump(int[] nums)
            {

                int[] dp = new int[nums.Length];

                dp[dp.Length - 1] = GOOD; // the last position can always reach out to itself

                for (int i = nums.Length - 2; i >= 0; i--)
                {
                    int maxJump = Math.Min(i + nums[i], nums.Length - 1);

                    for (int j = i + 1; j <= maxJump; j++)
                    {
                        if (dp[j] == GOOD)
                        {
                            dp[i] = GOOD;
                            break;
                        }
                    }

                }

                return dp[0] == GOOD;
            }
        }

        public class Greedy
        {
            public bool CanJump(int[] nums)
            {
                int lastPos = nums.Length - 1;
                for (int i = nums.Length - 1; i >= 0; i--)
                {
                    if (i + nums[i] >= lastPos)
                    {
                        lastPos = i;
                    }
                }
                return lastPos == 0;
            }
        }
    }
}
