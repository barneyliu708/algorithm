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

        public class SecondDone
        {
            public void Rotate(int[] nums, int k)
            {
                int len = nums.Length;
                k %= len;
                int cnt = 0;
                for (int i = 0; cnt < len; i++)
                {
                    int curidx = i;
                    int curval = nums[curidx];
                    do
                    {
                        int nextidx = (curidx + k) % len;
                        int nextval = nums[nextidx];
                        nums[nextidx] = curval;
                        curidx = nextidx;
                        curval = nextval;
                        cnt++;
                    }
                    while (curidx != i);
                }
            }
        }

        public class ThirdDone
        {
            public void Rotate(int[] nums, int k)
            {
                int n = nums.Length;
                int cnt = 0;
                for (int i = 0; cnt < n; i++)
                {
                    int j = (i + k) % n;
                    int pre = nums[i];
                    int cur = nums[j];
                    while (j != i)
                    {
                        nums[j] = pre;
                        pre = cur;
                        j = (j + k) % n;
                        cur = nums[j];
                        cnt++;
                        // Console.WriteLine(string.Join(',', nums) + "- cur: " + pre);
                    }
                    nums[j] = pre;
                    cnt++;
                }
            }
        }
    }
}
