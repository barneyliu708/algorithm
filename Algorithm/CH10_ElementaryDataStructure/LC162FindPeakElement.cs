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

        public class SecondDone
        {
            public int FindPeakElement(int[] nums)
            {
                int l = 0;
                int r = nums.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if (mid == (nums.Length - 1) || nums[mid] < nums[mid + 1])
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }

                return l == nums.Length ? l - 1 : l;
            }
        }
    }
}
