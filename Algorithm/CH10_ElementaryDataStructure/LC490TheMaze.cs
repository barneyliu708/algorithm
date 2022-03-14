using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC490TheMaze
    {
        public bool HasPath(int[][] maze, int[] start, int[] destination)
        {
            bool[,] visited = new bool[maze.Length, maze[0].Length];
            return HasPath(maze, start, destination, visited);
        }

        private bool HasPath(int[][] maze, int[] start, int[] destination, bool[,] visited)
        {
            if (visited[start[0], start[1]])
            {
                return false;
            }

            if (start[0] == destination[0] && start[1] == destination[1])
            {
                return true;
            }

            visited[start[0], start[1]] = true;

            int r = start[1] + 1;
            int l = start[1] - 1;
            int u = start[0] - 1;
            int d = start[0] + 1;

            while (r < maze[0].Length && maze[start[0]][r] != 1)
            {
                r++;
            }
            if (HasPath(maze, new int[] { start[0], r - 1 }, destination, visited))
            {
                return true;
            }

            while (l >= 0 && maze[start[0]][l] != 1)
            {
                l--;
            }
            if (HasPath(maze, new int[] { start[0], l + 1 }, destination, visited))
            {
                return true;
            }

            while (u >= 0 && maze[u][start[1]] != 1)
            {
                u--;
            }
            if (HasPath(maze, new int[] { u + 1, start[1] }, destination, visited))
            {
                return true;
            }

            while (d < maze.Length && maze[d][start[1]] != 1)
            {
                d++;
            }
            if (HasPath(maze, new int[] { d - 1, start[1] }, destination, visited))
            {
                return true;
            }

            return false;
        }
    }
}
