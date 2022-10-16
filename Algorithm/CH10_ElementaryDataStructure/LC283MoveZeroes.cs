using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC283MoveZeroes
    {
        public void MoveZeroes(int[] nums)
        {
            int l = 0;
            int r = 0;
            while (r < nums.Length)
            {
                if (nums[r] != 0)
                {
                    nums[l++] = nums[r];
                }
                r++;
            }

            while (l < nums.Length)
            {
                nums[l++] = 0;
            }
        }

        public class SecondDone
        {
            public void MoveZeroes(int[] nums)
            {
                int insert = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != 0)
                    {
                        Swap(nums, insert, i);
                        insert++;
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

        public class ThirdDone
        {
            public void MoveZeroes(int[] nums)
            {
                int l = 0;
                int r = 0;
                while (r < nums.Length)
                {
                    if (nums[r] != 0)
                    {
                        Swap(nums, l, r);
                        l++;
                    }
                    r++;
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
}
