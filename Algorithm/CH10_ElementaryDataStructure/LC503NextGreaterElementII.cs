using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC503NextGreaterElementII
    {
        public int[] NextGreaterElements(int[] nums)
        {

            Stack<int> stack = new Stack<int>();
            int[] ans = new int[nums.Length];

            for (int i = 0; i < nums.Length * 2; i++)
            {
                int cur = nums[i % nums.Length];
                while (stack.Count != 0 && nums[stack.Peek()] < cur)
                {
                    ans[stack.Pop()] = cur;
                }
                if (i < nums.Length)
                {
                    stack.Push(i);
                }
            }

            while (stack.Count != 0)
            {
                ans[stack.Pop()] = -1;
            }

            return ans;
        }
    }
}
