using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC075SortColors
    {
        public void SortColors(int[] nums)
        {

            int l = 0;
            int r = nums.Length - 1;
            int cur = 0;
            while (cur <= r)
            {
                if (nums[cur] == 0)
                {
                    Swap(nums, cur, l);
                    l++;
                    cur++; // there could be only 0s or 1s on the left side of cur
                }
                else if (nums[cur] == 2)
                {
                    Swap(nums, cur, r);
                    r--;
                }
                else
                {
                    cur++;
                }
            }
        }

        private void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
