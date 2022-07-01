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

        public class SecondDone_PrefixSum
        {
            public int Trap(int[] height)
            {
                int n = height.Length;
                int[] leftmax = new int[n];
                int[] rightmax = new int[n];
                for (int i = 0; i < n; i++)
                {
                    if (i == 0)
                    {
                        leftmax[i] = height[i];
                    }
                    else
                    {
                        leftmax[i] = Math.Max(height[i], leftmax[i - 1]);
                    }
                }
                for (int i = n - 1; i >= 0; i--)
                {
                    if (i == n - 1)
                    {
                        rightmax[i] = height[i];
                    }
                    else
                    {
                        rightmax[i] = Math.Max(height[i], rightmax[i + 1]);
                    }
                }
                int ans = 0;
                for (int i = 1; i < n - 1; i++)
                {
                    ans += Math.Max(0, Math.Min(leftmax[i - 1], rightmax[i + 1]) - height[i]);
                }
                return ans;
            }
        }
    }
}
