﻿using System;
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
    }
}
