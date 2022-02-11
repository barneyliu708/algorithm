using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC162FindPeakElement
    {
        public int FindPeakElement(int[] nums)
        {

            int start = 0;
            int end = nums.Length - 1;

            while (start < end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] > nums[mid + 1])
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return end;
        }
    }
}
