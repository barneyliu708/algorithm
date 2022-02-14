using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC026RemoveDuplicatesFromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
            {
                return nums.Length;
            }

            int pointer = 1;
            int insert = 1;

            while (pointer < nums.Length)
            {
                if (nums[pointer] != nums[pointer - 1])
                {
                    nums[insert] = nums[pointer];
                    insert++;
                }
                pointer++;
            }

            return insert;
        }
    }
}
