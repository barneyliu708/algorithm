using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC1762BuildingsWithAnOceanView
    {
        public int[] FindBuildings(int[] heights)
        {

            int curMax = -1;
            List<int> indices = new List<int>();
            for (int i = heights.Length - 1; i >= 0; i--)
            {
                if (heights[i] > curMax)
                {
                    indices.Add(i);
                    curMax = heights[i];
                }
            }

            // swap the indices in the array
            for (int i = 0; i < indices.Count / 2; i++)
            {
                int temp = indices[i];
                indices[i] = indices[indices.Count - 1 - i];
                indices[indices.Count - 1 - i] = temp;
            }

            return indices.ToArray();
        }

        public int[] FindBuildings_MonotonicStack(int[] heights)
        {

            Stack<int> stack = new Stack<int>();
            List<int> indices = new List<int>();
            for (int i = heights.Length - 1; i >= 0; i--)
            {
                while (stack.Count != 0 && heights[i] > heights[stack.Peek()])
                {
                    stack.Pop();
                }

                if (stack.Count == 0)
                {
                    indices.Add(i);
                }

                stack.Push(i);
            }

            // reverse the indices in the list
            indices.Reverse();

            return indices.ToArray();
        }

        public class SecondDone
        {
            public int[] FindBuildings(int[] heights)
            {

                int maxhight = int.MinValue;
                List<int> indices = new List<int>();
                for (int i = heights.Length - 1; i >= 0; i--)
                {

                    if (heights[i] <= maxhight)
                    {
                        continue;
                    }

                    maxhight = heights[i];

                    indices.Add(i);

                }

                // reverse the indices in the list
                indices.Reverse();

                return indices.ToArray();
            }
        }
    }
}
