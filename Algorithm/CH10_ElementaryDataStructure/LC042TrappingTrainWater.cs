using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC042TrappingTrainWater
    {
        public int Trap(int[] height)
        {
            int ans = 0;
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < height.Length; i++)
            {

                while (stack.Count != 0 && height[i] > height[stack.Peek()])
                {
                    int bottomIdx = stack.Pop();
                    if (stack.Count == 0)
                    {
                        break;
                    }
                    int leftbarIdx = stack.Peek();
                    int len = i - leftbarIdx - 1;
                    int hei = Math.Min(height[i], height[leftbarIdx]) - height[bottomIdx];
                    ans += hei * len;
                }

                stack.Push(i);
            }
            return ans;
        }
    }
}
