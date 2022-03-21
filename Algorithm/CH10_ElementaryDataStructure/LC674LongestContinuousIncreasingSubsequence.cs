using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC674LongestContinuousIncreasingSubsequence
    {
        public int FindLengthOfLCIS(int[] nums)
        {

            if (nums.Length < 2)
            {
                return nums.Length;
            }

            int ans = 1;
            int l = 0;
            int r = 1;
            while (r < nums.Length)
            {
                if (nums[r] > nums[r - 1])
                {
                    ans = Math.Max(ans, r - l + 1);
                }
                else
                {
                    l = r;
                }
                r++;
            }

            return ans;
        }
    }
}
