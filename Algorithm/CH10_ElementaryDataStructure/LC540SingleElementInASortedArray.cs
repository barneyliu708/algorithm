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
    }
}
