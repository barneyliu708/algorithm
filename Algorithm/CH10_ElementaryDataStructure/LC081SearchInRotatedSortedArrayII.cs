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

        class SecondTrial
        {
            // the only real scenario we should look out for is when we're given an array
            // where the first element == last element like in the following: 2, 5, 6, 0, 0, 1, 2 .
            // Then we can just shrink our array on both sides, the left and the right, so that we could just perform the regular binary search on a rotated array algorithm.
            // It would give us this array: 5, 6, 0, 0, 1 to work with.
            public bool Search(int[] nums, int target)
            {

                int l = 0;
                int r = nums.Length - 1;

                while (l <= r && nums[l] == nums[r])
                {
                    if (nums[l] == target)
                    {
                        return true;
                    }
                    l++;
                    r--;
                }

                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (nums[mid] == target)
                    {
                        return true;
                    }
                    if (nums[mid] >= nums[l])
                    {
                        if (target >= nums[l] && target < nums[mid])
                        {
                            r = mid - 1;
                        }
                        else
                        {
                            l = mid + 1;
                        }
                    }
                    else
                    {
                        if (target <= nums[r] && target > nums[mid])
                        {
                            l = mid + 1;
                        }
                        else
                        {
                            r = mid - 1;
                        }
                    }
                }

                return false;
            }
        }
    }
}
