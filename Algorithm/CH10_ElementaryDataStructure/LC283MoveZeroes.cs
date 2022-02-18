using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC283MoveZeroes
    {
        public void MoveZeroes(int[] nums)
        {
            int l = 0;
            int r = 0;
            while (r < nums.Length)
            {
                if (nums[r] != 0)
                {
                    nums[l++] = nums[r];
                }
                r++;
            }

            while (l < nums.Length)
            {
                nums[l++] = 0;
            }
        }
    }
}
