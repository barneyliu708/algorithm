using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1060MissingElementInSortedArray
    {
        public int MissingElement(int[] nums, int k)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l <= r)
            {
                int mid = l + (r - l) / 2;
                int count = MissingCount(nums, mid);

                // need to find the leftmost potential index of target
                if (count == k) 
                { 
                    r = mid - 1;
                }
                else if (count > k)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return nums[l - 1] + k - MissingCount(nums, l - 1);
        }

        private int MissingCount(int[] nums, int i)
        {
            return nums[i] - nums[0] - i;
        }

        public class SecondDone
        {
            public int MissingElement(int[] nums, int k)
            {
                int l = 0;
                int r = nums.Length - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    int count = MissingCount(nums, mid);
                    if (count == k)
                    { // need to find the leftmost potential index of target
                        r = mid - 1;
                    }
                    else if (count > k)
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }
                return nums[r] + k - MissingCount(nums, r);
            }

            private int MissingCount(int[] nums, int i)
            {
                return nums[i] - nums[0] - i;
            }
        }
    }
}
