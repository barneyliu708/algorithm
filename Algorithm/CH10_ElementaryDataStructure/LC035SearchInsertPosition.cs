using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC035SearchInsertPosition
    {
        public int SearchInsert(int[] nums, int target)
        {
            int start = 0, end = nums.Length - 1;
            while (start <= end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return start;
        }
    }
}
