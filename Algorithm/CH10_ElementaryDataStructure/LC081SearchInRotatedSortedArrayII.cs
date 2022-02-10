using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC081SearchInRotatedSortedArrayII
    {
        public bool Search(int[] nums, int target)
        {

            int pivot = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    pivot = i;
                }
            }

            int start = -1;
            int end = -1;
            if (target >= nums[pivot] && target <= nums[nums.Length - 1])
            {
                start = pivot;
                end = nums.Length - 1;
            }
            else
            {
                start = 0;
                end = pivot - 1;
            }

            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] == target)
                {
                    return true;
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

            return false;
        }
    }
}
