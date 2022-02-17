using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC189RotateArray
    {
        public void Rotate(int[] nums, int k)
        {

            k %= nums.Length;

            int count = 0;
            for (int start = 0; count < nums.Length; start++)
            {
                int curIndex = start;
                int curValue = nums[curIndex];
                do
                {
                    int nextIndex = (curIndex + k) % nums.Length;
                    int nextValue = nums[nextIndex];

                    nums[nextIndex] = curValue;
                    curIndex = nextIndex;
                    curValue = nextValue;

                    count++;
                }
                while (curIndex != start);
            }
        }
    }
}
