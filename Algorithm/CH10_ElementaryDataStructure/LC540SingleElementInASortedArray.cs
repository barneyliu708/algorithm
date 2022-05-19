using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC540SingleElementInASortedArray
    {
        public int SingleNonDuplicate(int[] nums)
        {

            if (nums.Length == 1)
            {
                return nums[0];
            }

            int start = 0;
            int end = nums.Length - 1;

            while (start <= end)
            {
                int mid = start + (end - start) / 2;

                if ((mid == 0 && nums[mid] != nums[mid + 1]) ||
                    (mid == nums.Length - 1 && nums[mid] != nums[mid - 1]) ||
                    (nums[mid] != nums[mid + 1] && nums[mid] != nums[mid - 1]))
                {
                    return nums[mid];
                }
                else if (nums[mid] == nums[mid + 1])
                {
                    if ((mid - start) % 2 == 0)
                    {
                        start = mid + 2;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
                else // nums[mid - 1] == nums[mid]
                { 
                    if ((end - mid) % 2 == 0)
                    {
                        end = mid - 2;
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
            }

            return int.MinValue; // the returned value here does not matter
        }

        public class SecondDone
        {
            public int SingleNonDuplicate(int[] nums)
            {
                if (nums.Length == 1)
                {
                    return nums[0];
                }

                int l = 0;
                int r = nums.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    if ((mid == 0 && nums[mid] != nums[mid + 1]) ||
                        (mid == nums.Length - 1 && nums[mid] != nums[mid - 1]) ||
                        (nums[mid] != nums[mid + 1] && nums[mid] != nums[mid - 1]))
                    {
                        return nums[mid];
                    }

                    // if there is no single element, the even-index should equal to its next odd-index, 0th == 1th, 2th == 3th, ...
                    // otherwise, it contains a single value element
                    if ((mid % 2 == 1 && nums[mid] == nums[mid - 1]) ||
                        (mid % 2 == 0 && nums[mid] == nums[mid + 1]))
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }

                return -1;
            }
        }
    }
}
