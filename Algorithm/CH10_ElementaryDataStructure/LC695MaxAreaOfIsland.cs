using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC695MaxAreaOfIsland
    {

        private int curCount = 0;
        private int maxCount = 0;

        public int MaxAreaOfIsland(int[][] grid)
        {
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 0)
                    {
                        continue;
                    }
                    curCount = 0;
                    Area(grid, i, j);
                    maxCount = Math.Max(maxCount, curCount);
                }
            }
            return maxCount;
        }

        private void Area(int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length ||
                j < 0 || j >= grid[0].Length ||
                grid[i][j] == 0)
            {
                return;
            }

            curCount++;
            grid[i][j] = 0;

            Area(grid, i + 1, j);
            Area(grid, i - 1, j);
            Area(grid, i, j + 1);
            Area(grid, i, j - 1);
        }
    }
}
