using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC080RemoveDuplicatesFromSortedArrayII
    {
        public int RemoveDuplicates(int[] nums)
        {

            int l = 0;
            int r = 0;

            int pre = int.MinValue;
            int count = 0;
            while (r < nums.Length)
            {
                if (r == 0 || nums[r - 1] != nums[r])
                {
                    count = 1;
                    nums[l++] = nums[r];
                }
                else
                {
                    count++;
                    if (count <= 2)
                    {
                        nums[l++] = nums[r];
                    }
                }
                r++;
            }

            return l;
        }
    }
}
