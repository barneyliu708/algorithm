using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC724FindPivotIndex
    {
        public int PivotIndex(int[] nums)
        {
            int n = nums.Length;
            int postSum = 0;
            int[] postSums = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                postSums[i] = postSum;
                postSum += nums[i];
            }

            int preSum = 0;
            for (int i = 0; i < n; i++)
            {
                if (preSum == postSums[i])
                {
                    return i;
                }
                preSum += nums[i];
            }

            return -1;
        }
    }
}
