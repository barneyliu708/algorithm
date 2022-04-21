using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    [TestFixture]
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


        public class SecondDone
        {
            public bool HasPath(int[][] maze, int[] start, int[] destination)
            {
                bool[,] visited = new bool[maze.Length, maze[0].Length];
                int[][] directions = new int[][] {
            new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { 1, 0 }, new int[] { -1, 0 }
        };
                Queue<int[]> queue = new Queue<int[]>();
                queue.Enqueue(start);
                while (queue.Count > 0)
                {
                    int[] s = queue.Dequeue();
                    visited[s[0], s[1]] = true;
                    if (s[0] == destination[0] && s[1] == destination[1])
                    {
                        return true;
                    }
                    foreach (int[] dir in directions)
                    {
                        int[] p = new int[] { s[0], s[1] };
                        while (CanMoveForward(maze, p, dir))
                        {
                            p[0] += dir[0];
                            p[1] += dir[1];
                        }
                        if (!visited[p[0], p[1]])
                        {
                            queue.Enqueue(p);
                        }
                    }
                }
                return false;
            }

            private bool CanMoveForward(int[][] maze, int[] position, int[] direction)
            {
                int[] next = new int[] { position[0] + direction[0], position[1] + direction[1] };
                return next[0] >= 0 && next[0] < maze.Length &&
                       next[1] >= 0 && next[1] < maze[0].Length &&
                       maze[next[0]][next[1]] != 1;
            }

            [Test] 
            public void TestCase1()
            {
                int[][] maze = new int[][]
                {
                    new int[] {0, 0, 1, 0, 0 },
                    new int[] {0, 0, 0, 0, 0 },
                    new int[] {0, 0, 0, 1, 0 },
                    new int[] {1, 1, 0, 1, 1 },
                    new int[] {0, 0, 0, 0, 0 }
                };
                int[] start = new int[] { 0, 4 };
                int[] destination = new[] { 4, 4 };

                var test = HasPath(maze, start, destination);
            }
        }
    }
}
