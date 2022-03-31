using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC027RemoveElement
    {
        public int RemoveElement(int[] nums, int val)
        {

            int p = 0;
            int i = 0;
            while (p < nums.Length)
            {
                if (nums[p] != val)
                {
                    nums[i] = nums[p];
                    i++;
                }
                p++;
            }

            return i;
        }

        public class SecondDone
        {
            public int RemoveElement(int[] nums, int val)
            {
                int inject = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] != val)
                    {
                        nums[inject] = nums[i];
                        inject++;
                    }
                }
                return inject;
            }
        }
    }
}
