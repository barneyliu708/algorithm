using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC280WiggleSort
    {
        public void WiggleSort(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if ((i % 2 == 0 && nums[i] > nums[i + 1]) || (i % 2 == 1 && nums[i] < nums[i + 1]))
                {
                    Swap(nums, i, i + 1);
                }
            }
        }

        public void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
