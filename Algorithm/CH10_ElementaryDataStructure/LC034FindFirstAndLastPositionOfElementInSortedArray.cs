using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC034FindFirstAndLastPositionOfElementInSortedArray
    {
        public int[] SearchRange(int[] nums, int target)
        {

            int[] ans = new int[] { -1, -1 };

            if (nums.Length == 0)
            {
                return ans;
            }

            ans[0] = SearchLowerBoundary(nums, target);
            ans[1] = SearchUpperBoundary(nums, target);

            return ans;
        }

        private int SearchLowerBoundary(int[] nums, int target)
        {

            int start = 0, end = nums.Length - 1;
            while (start < end)
            {
                int mid = (start + end) / 2;
                if (nums[mid] == target)
                {
                    end = mid;
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

            if (nums[start] != target)
            {
                return -1;
            }

            return start;
        }

        private int SearchUpperBoundary(int[] nums, int target)
        {

            int start = 0, end = nums.Length - 1;
            while (start < end)
            {
                int mid = (start + end + 1) / 2;
                if (nums[mid] == target)
                {
                    start = mid;
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

            if (nums[end] != target)
            {
                return -1;
            }

            return end;
        }
    }
}
