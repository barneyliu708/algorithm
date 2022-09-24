using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC084LargestRectangleInHistogram
    {
        public int LargestRectangleArea(int[] heights)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int maxArea = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                while (stack.Peek() != -1 && heights[stack.Peek()] >= heights[i])
                {
                    int currentHeight = heights[stack.Peek()];
                    stack.Pop();
                    int currentWidth = i - stack.Peek() - 1;
                    maxArea = Math.Max(maxArea, currentHeight * currentWidth);
                }
                stack.Push(i);
            }
            while (stack.Peek() != -1)
            {
                int currentHeight = heights[stack.Peek()];
                stack.Pop();
                int currentWidth = heights.Length - stack.Peek() - 1;
                maxArea = Math.Max(maxArea, currentHeight * currentWidth);
            }

            return maxArea;
        }

        public class SecondDone
        {
            public int LargestRectangleArea(int[] heights)
            {
                Stack<int> stack = new Stack<int>(); // stack of index
                stack.Push(-1);

                int ans = 0;
                for (int i = 0; i < heights.Length; i++)
                {
                    while (stack.Peek() != -1 && heights[stack.Peek()] >= heights[i])
                    {
                        int curHeight = heights[stack.Pop()];
                        int curWidth = i - stack.Peek() - 1; // exclude both left and right boundary
                        ans = Math.Max(ans, curHeight * curWidth);
                    }
                    stack.Push(i);
                }

                while (stack.Peek() != -1)
                { // exclude the last element -1
                    int curHeight = heights[stack.Pop()];
                    int curWidth = heights.Length - stack.Peek() - 1;
                    ans = Math.Max(ans, curHeight * curWidth);
                }

                return ans;
            }
        }
    }
}
