using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC1091ShortestPathInBinaryMatrix
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {

            bool[,] visited = new bool[grid.Length, grid[0].Length];
            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();

            queue.Enqueue((0, 0));

            int path = 0;
            while (queue.Count > 0)
            {
                path++;
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    (int row, int col) cur = queue.Dequeue();

                    if (visited[cur.row, cur.col] || grid[cur.row][cur.col] == 1)
                    {
                        continue;
                    }

                    visited[cur.row, cur.col] = true;
                    if (cur.row == grid.Length - 1 && cur.col == grid[0].Length - 1)
                    {
                        return path;
                    }

                    foreach (int r in new int[] { cur.row - 1, cur.row, cur.row + 1 })
                    {
                        foreach (int c in new int[] { cur.col - 1, cur.col, cur.col + 1 })
                        {
                            if (r >= 0 && r < grid.Length &&
                                c >= 0 && c < grid[0].Length &&
                                !visited[r, c] && grid[r][c] == 0)
                            {
                                queue.Enqueue((r, c));
                            }
                        }
                    }
                }
            }
            return -1;
        }
    }
}
