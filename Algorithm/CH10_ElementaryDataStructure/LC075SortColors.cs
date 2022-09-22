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

        public class SecondDone
        {
            public void SortColors(int[] nums)
            {
                int l = 0;
                int r = nums.Length - 1;
                for (int i = 0; i <= r; i++)
                {
                    if (nums[i] == 0)
                    {
                        Swap(nums, i, l);
                        l++;
                    }
                }
                for (int i = nums.Length - 1; i >= l; i--)
                {
                    if (nums[i] == 2)
                    {
                        Swap(nums, i, r);
                        r--;
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
            public void SortColors(int[] nums)
            {
                int l = 0;
                int r = nums.Length - 1;
                int i = 0;
                while (i <= r)
                {
                    if (nums[i] == 1)
                    {
                        i++;
                    }
                    else if (nums[i] == 0)
                    {
                        Swap(nums, i, l);
                        l++;
                        i++;
                    }
                    else
                    {
                        Swap(nums, i, r);
                        r--;
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
}
