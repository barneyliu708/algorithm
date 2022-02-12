using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC287FindTheDuplicateNumber
    {
        public int FindDuplicate(int[] nums)
        {

            for (int i = 0; i < nums.Length; i++)
            {
                int index = Math.Abs(nums[i]) - 1;
                if (nums[index] < 0)
                {
                    return index + 1;
                }
                nums[index] *= -1;
            }



            return int.MinValue;
        }
    }
}
