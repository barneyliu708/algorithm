using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC694NumberOfDistinctIslands
    {
        public int NumDistinctIslands(int[][] grid)
        {

            HashSet<string> ans = new HashSet<string>();
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        StringBuilder curIsland = new StringBuilder();
                        DftIsland(grid, i, j, i, j, curIsland);
                        ans.Add(curIsland.ToString());
                    }
                }
            }

            return ans.Count;
        }

        private void DftIsland(int[][] grid, int si, int sj, int i, int j, StringBuilder curIsland)
        {
            if (i < 0 || j < 0 || i >= grid.Length || j >= grid[0].Length || grid[i][j] != 1)
            {
                return;
            }

            grid[i][j] = 2;
            // hash the island shape into a string
            curIsland.Append(i - si);
            curIsland.Append(j - sj);

            DftIsland(grid, si, sj, i + 1, j, curIsland);
            DftIsland(grid, si, sj, i - 1, j, curIsland);
            DftIsland(grid, si, sj, i, j + 1, curIsland);
            DftIsland(grid, si, sj, i, j - 1, curIsland);
        }
    }
}
