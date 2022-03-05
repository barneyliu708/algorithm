using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC494TargetSum
    {
        class BacktrackingApproach
        {
            private int count;

            public int FindTargetSumWays(int[] nums, int target)
            {
                FindTarget(nums, target, 0, 0);
                return count;
            }

            private void FindTarget(int[] nums, int target, int i, int curSum)
            {
                if (i == nums.Length)
                {
                    if (curSum == target)
                    {
                        count++;
                    }
                }
                else
                {
                    FindTarget(nums, target, i + 1, curSum + nums[i]);
                    FindTarget(nums, target, i + 1, curSum - nums[i]);
                }
            }
        }
    }
}
