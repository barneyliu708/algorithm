using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC033SearchInRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {

            int start = 0, end = nums.Length - 1;
            while (start <= end)
            {
                int mid = start + (end - start) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                else if (nums[mid] >= nums[start])
                {
                    if (target >= nums[start] && target < nums[mid])
                    {
                        end = mid - 1;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    if (target > nums[mid] && target <= nums[end])
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }

            return -1;
        }

        class SecondTrial
        {
            public int Search(int[] nums, int target)
            {
                int l = 0;
                int r = nums.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (nums[mid] == target)
                    {
                        return mid;
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

                return -1;
            }
        }
    }
}
