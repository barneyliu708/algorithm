using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC356LineReflection
    {
        public bool IsReflected(int[][] points)
        {

            Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>(); // x - y[];
            int xmax = points[0][0];
            int xmin = points[0][0];
            foreach (int[] point in points)
            {
                int x = point[0];
                int y = point[1];

                xmax = Math.Max(xmax, x);
                xmin = Math.Min(xmin, x);

                if (!map.ContainsKey(x))
                {
                    map[x] = new HashSet<int>();
                }
                map[x].Add(y);
            }

            foreach (int[] point in points)
            {
                int x = point[0];
                int x_ = xmax + xmin - x;
                int y = point[1];

                if (!map.ContainsKey(x_) || !map[x_].Contains(y))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
