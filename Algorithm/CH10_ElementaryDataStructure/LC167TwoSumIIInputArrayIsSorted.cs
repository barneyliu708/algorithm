using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC167TwoSumIIInputArrayIsSorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {

            int start = 0;
            int end = numbers.Length - 1;
            int[] ans = new int[2];
            while (start < end)
            {
                int sum = numbers[start] + numbers[end];

                if (sum == target)
                {
                    return new int[] { start + 1, end + 1 };
                }
                else if (sum > target)
                {
                    end--;
                }
                else
                {
                    start++;
                }
            }

            return new int[] { -1, -1 };
        }
    }
}
