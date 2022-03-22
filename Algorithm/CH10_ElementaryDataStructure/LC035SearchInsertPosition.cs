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

        public class SecondTrial
        {
            public int SearchInsert(int[] nums, int target)
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
                    if (nums[mid] > target)
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                return l;
            }
        }
    }
}
