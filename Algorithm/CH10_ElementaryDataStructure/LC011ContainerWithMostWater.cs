using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC011ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {

            int ans = 0;
            int l = 0;
            int r = height.Length - 1;
            while (l < r)
            {
                ans = Math.Max(ans, (r - l) * Math.Min(height[l], height[r]));
                if (height[l] < height[r])
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }
            return ans;
        }
    }
}
