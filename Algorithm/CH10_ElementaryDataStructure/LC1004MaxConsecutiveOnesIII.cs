using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1004MaxConsecutiveOnesIII
    {
        public int LongestOnes(int[] nums, int k)
        {
            int l = 0;
            int r = 0;
            int ans = 0;
            while (r < nums.Length)
            {
                if (nums[r] == 0)
                {
                    k--;
                }

                while (k < 0)
                {
                    if (nums[l] == 0)
                    {
                        k++;
                    }
                    l++;
                }

                ans = Math.Max(ans, r - l + 1);

                r++;
            }
            return ans;
        }
    }
}
