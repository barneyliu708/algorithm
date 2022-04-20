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

        public class BFTApproach
        {
            public int NumIslands(char[][] grid)
            {
                int numIsland = 0;
                int nrow = grid.Length;
                int ncol = grid[0].Length;
                for (int r = 0; r < nrow; r++)
                {
                    for (int c = 0; c < ncol; c++)
                    {
                        if (grid[r][c] == '1')
                        {
                            numIsland++;

                            // bread-first traversal to mark the whole island
                            Queue<int> queue = new Queue<int>();
                            queue.Enqueue(r * ncol + c);
                            while (queue.Count > 0)
                            {
                                int id = queue.Dequeue();
                                int col = id % ncol;
                                int row = id / ncol;
                                grid[row][col] = '0';

                                if (row - 1 >= 0 && grid[row - 1][col] == '1')
                                {
                                    grid[row - 1][col] = '0';
                                    queue.Enqueue((row - 1) * ncol + col);
                                }

                                if (row + 1 < nrow && grid[row + 1][col] == '1')
                                {
                                    grid[row + 1][col] = '0';
                                    queue.Enqueue((row + 1) * ncol + col);
                                }

                                if (col - 1 >= 0 && grid[row][col - 1] == '1')
                                {
                                    grid[row][col - 1] = '0';
                                    queue.Enqueue(row * ncol + col - 1);
                                }

                                if (col + 1 < ncol && grid[row][col + 1] == '1')
                                {
                                    grid[row][col + 1] = '0';
                                    queue.Enqueue(row * ncol + col + 1);
                                }
                            }
                        }
                    }
                }

                return numIsland;
            }
        }
    }
}
