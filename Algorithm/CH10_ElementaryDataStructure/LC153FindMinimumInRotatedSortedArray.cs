using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC153FindMinimumInRotatedSortedArray
    {
        public int FindMin(int[] nums)
        {

            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if (nums[mid] > nums[(mid + 1) % nums.Length])
                {
                    return nums[(mid + 1) % nums.Length];
                }
                else if (nums[mid] < nums[start])
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return nums[start % nums.Length];
        }
    }
}
