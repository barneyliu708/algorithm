using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1031MaximumSumOfTwoNonOverlappingSubarrays
    {
        public int MaxSumTwoNoOverlap(int[] nums, int firstLen, int secondLen)
        {
            return Math.Max(MaxSum(nums, firstLen, secondLen), MaxSum(nums, secondLen, firstLen));
        }

        private int MaxSum(int[] nums, int firstLen, int secondLen)
        {
            int n = nums.Length;

            int[] leftmax = new int[n];
            int subsum = 0;
            int maxsum = 0;
            for (int i = 0; i < n; i++)
            {
                subsum += nums[i];
                if (i > firstLen - 1)
                {
                    subsum -= nums[i - firstLen];
                }
                maxsum = Math.Max(maxsum, subsum);
                leftmax[i] = maxsum;
            }

            subsum = 0;
            maxsum = 0;
            int[] rightmax = new int[n];
            for (int i = n - 1; i >= 0; i--)
            {
                subsum += nums[i];
                if (i < n - secondLen)
                {
                    subsum -= nums[i + secondLen];
                }
                maxsum = Math.Max(maxsum, subsum);
                rightmax[i] = maxsum;
            }

            int max = 0;
            for (int i = firstLen - 1; i < n - secondLen; i++)
            {
                max = Math.Max(max, leftmax[i] + rightmax[i + 1]);
            }

            return max;
        }
    }
}
