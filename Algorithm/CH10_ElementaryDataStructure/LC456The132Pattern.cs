using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC456The132Pattern
    {
        public bool Find132pattern(int[] nums)
        {

            Stack<int> stack = new Stack<int>();
            int[] min = new int[nums.Length];
            min[0] = nums[0];
            for (int i = 1; i < nums.Length; i++)
            {
                min[i] = Math.Min(min[i - 1], nums[i]);
            }
            for (int j = nums.Length - 1; j >= 0; j--)
            {
                while (stack.Count != 0 && stack.Peek() <= min[j])
                {
                    stack.Pop();
                }
                if (stack.Count != 0 && stack.Peek() < nums[j])
                {
                    return true;
                }
                if (stack.Count == 0 || stack.Peek() >= nums[j])
                {
                    stack.Push(nums[j]);
                }
            }
            return false;
        }
    }
}
