using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC031NextPermutation
    {
        public void NextPermutation(int[] nums)
        {
            int i = nums.Length - 2;
            while (i >= 0 && nums[i] >= nums[i + 1])
            {
                i--;
            }
            if (i >= 0)
            {
                int j = nums.Length - 1;
                while (nums[j] <= nums[i])
                {
                    j--;
                }
                Swap(nums, i, j);
            }
            Reverse(nums, i + 1);
        }

        public void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public void Reverse(int[] nums, int start)
        {
            int i = start;
            int j = nums.Length - 1;
            while (i < j)
            {
                Swap(nums, i, j);
                i++;
                j--;
            }
        }

        public class SecondDone
        {
            public void NextPermutation(int[] nums)
            {
                if (nums.Length <= 1)
                {
                    return;
                }

                int i = nums.Length - 2;
                while (i >= 0 && nums[i] >= nums[i + 1])
                {
                    i--;
                }

                if (i == -1)
                {
                    Reverse(nums, 0, nums.Length - 1);
                    return;
                }

                int j = i + 1;
                while (j < nums.Length && nums[j] > nums[i])
                {
                    j++;
                }
                j--;

                Swap(nums, i, j);
                Reverse(nums, i + 1, nums.Length - 1);
            }

            private void Swap(int[] nums, int i, int j)
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }

            private void Reverse(int[] nums, int i, int j)
            {
                while (i < j)
                {
                    Swap(nums, i, j);
                    i++;
                    j--;
                }
            }
        }
    }
}
