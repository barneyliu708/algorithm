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


    }
}
