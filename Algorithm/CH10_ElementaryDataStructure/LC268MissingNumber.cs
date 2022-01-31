using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC268MissingNumber
    {
        public int MissingNumber(int[] nums)
        {

            int n = nums.Length;
            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }

            return (0 + n) * (n + 1) / 2 - sum;
        }
    }
}
