using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC238ProductOfArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int[] prefix = new int[nums.Length];
            int[] suffix = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    prefix[i] = nums[i];
                }
                else
                {
                    prefix[i] = prefix[i - 1] * nums[i];
                }
            }

            for (int i = nums.Length - 1; i >= 0; i--)
            {
                if (i == nums.Length - 1)
                {
                    suffix[i] = nums[i];
                }
                else
                {
                    suffix[i] = suffix[i + 1] * nums[i];
                }
            }

            int[] ans = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                if (i == 0)
                {
                    ans[i] = suffix[i + 1];
                }
                else if (i == nums.Length - 1)
                {
                    ans[i] = prefix[i - 1];
                }
                else
                {
                    ans[i] = prefix[i - 1] * suffix[i + 1];
                }
            }

            return ans;
        }
    }
}
