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

        public class SecondDone
        {
            public int MaxSumTwoNoOverlap(int[] nums, int firstLen, int secondLen)
            {
                int n = nums.Length;
                int[] sum1 = new int[n];
                int[] sum2 = new int[n];
                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        sum1[i] = nums[i];
                        sum2[i] = nums[i];
                    }
                    else
                    {
                        sum1[i] = sum1[i - 1] + nums[i];
                        sum2[i] = sum2[i - 1] + nums[i];

                        if (i >= firstLen)
                        {
                            sum1[i] -= nums[i - firstLen];
                        }
                        if (i >= secondLen)
                        {
                            sum2[i] -= nums[i - secondLen];
                        }
                    }
                }

                int[] rmax1 = new int[n];
                int[] rmax2 = new int[n];
                for (int i = n - 1; i >= 0; i--)
                {
                    if (i == n - 1)
                    {
                        rmax1[i] = sum1[i];
                        rmax2[i] = sum2[i];
                    }
                    else
                    {
                        rmax1[i] = Math.Max(rmax1[i + 1], sum1[i]);
                        rmax2[i] = Math.Max(rmax2[i + 1], sum2[i]);
                    }
                }

                int ans = 0;
                for (int i = firstLen - 1; i + secondLen < n; i++)
                {
                    ans = Math.Max(ans, sum1[i] + rmax2[i + secondLen]);
                }
                for (int i = secondLen - 1; i + firstLen < n; i++)
                {
                    ans = Math.Max(ans, sum2[i] + rmax1[i + firstLen]);
                }

                return ans;
            }
        }
    }
}
