using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC200NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            // 0 = watet, 1 = land, 2 = visited
            int island = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '1')
                    { // new unvisited island 
                        island++;
                    }
                    Dft(grid, i, j);
                }
            }

            return island;
        }

        private void Dft(char[][] grid, int i, int j)
        {

            if (i < 0 || i >= grid.Length ||
                j < 0 || j >= grid[0].Length)
            {
                return;
            }

            if (grid[i][j] == '0' || grid[i][j] == '2')
            {
                return;
            }

            if (grid[i][j] == '1')
            {
                grid[i][j] = '2';
            }

            Dft(grid, i + 1, j);
            Dft(grid, i - 1, j);
            Dft(grid, i, j + 1);
            Dft(grid, i, j - 1);
        }
    }
}
