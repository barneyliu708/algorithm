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

        public class SecondDone
        {
            public int FindLengthOfLCIS(int[] nums)
            {
                int cur = 1;
                int ans = 1;
                for (int i = 1; i < nums.Length; i++)
                {
                    if (nums[i] > nums[i - 1])
                    {
                        cur++;
                        ans = Math.Max(ans, cur);
                    }
                    else
                    {
                        cur = 1;
                    }
                }
                return ans;
            }
        }
    }
}
