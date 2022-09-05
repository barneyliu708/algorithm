using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC542_01Matrix
    {
        public int[][] UpdateMatrix(int[][] mat)
        {
            Queue<(int row, int col)> queue = new Queue<(int row, int col)>();
            int[][] distances = new int[mat.Length][];
            for (int i = 0; i < mat.Length; i++)
            {
                distances[i] = new int[mat[0].Length];
                for (int j = 0; j < mat[0].Length; j++)
                {
                    distances[i][j] = int.MaxValue;
                    if (mat[i][j] == 0)
                    {
                        queue.Enqueue((i, j)); // push all 0s to the queue
                    }
                }
            }

            int dist = 0;
            while (queue.Count > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {

                    (int row, int col) cur = queue.Dequeue();
                    distances[cur.row][cur.col] = Math.Min(distances[cur.row][cur.col], dist);

                    (int row, int col)[] neibors = new (int row, int col)[] {
                        (cur.row - 1, cur.col),
                        (cur.row + 1, cur.col),
                        (cur.row, cur.col - 1),
                        (cur.row, cur.col + 1)
                    };
                    // add valid neibors into the queue for next round of iteration
                    foreach ((int row, int col) neibor in neibors)
                    {
                        if (neibor.row < 0 || neibor.col < 0 ||
                            neibor.row >= mat.Length || neibor.col >= mat[0].Length ||
                            distances[neibor.row][neibor.col] != int.MaxValue)
                        {
                            continue;
                        }
                        queue.Enqueue((neibor.row, neibor.col));
                    }
                }
                dist++;
            }

            return distances;
        }

        public class SecondDone
        {
            public int[][] UpdateMatrix(int[][] mat)
            {
                (int r, int c)[] neighbors = new (int r, int c)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

                bool[,] visited = new bool[mat.Length, mat[0].Length];
                Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
                for (int i = 0; i < mat.Length; i++)
                {
                    for (int j = 0; j < mat[0].Length; j++)
                    {
                        if (mat[i][j] == 0)
                        {
                            queue.Enqueue((i, j));
                        }
                    }
                }
                int dist = 0;
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    // breadth-first traversal on current level
                    for (int cnt = 0; cnt < count; cnt++)
                    {
                        (int r, int c) cur = queue.Dequeue();
                        if (visited[cur.r, cur.c])
                        {
                            continue;
                        }
                        visited[cur.r, cur.c] = true;
                        if (mat[cur.r][cur.c] == 1)
                        {
                            mat[cur.r][cur.c] = dist;
                        }
                        if (mat[cur.r][cur.c] == 0)
                        {
                            mat[cur.r][cur.c] = 0;
                        }

                        foreach ((int r, int c) nb in neighbors)
                        {
                            int row = cur.r + nb.r;
                            int col = cur.c + nb.c;
                            if (row >= 0 && row < mat.Length && col >= 0 && col < mat[0].Length && mat[row][col] == 1)
                            {
                                queue.Enqueue((row, col));
                            }
                        }
                    }
                    dist++;
                }

                return mat;
            }
        }

        public class ThirdDone
        {
            public int[][] UpdateMatrix(int[][] mat)
            {

                for (int i = 0; i < mat.Length; i++)
                {
                    for (int j = 0; j < mat[0].Length; j++)
                    {
                        mat[i][j] = Distance(mat, (i, j));
                    }
                }

                return mat;
            }

            private int Distance(int[][] mat, (int r, int c) root)
            {
                if (mat[root.r][root.c] == 0)
                {
                    return 0;
                }
                (int r, int c)[] neighbors = new (int r, int c)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };
                bool[,] visited = new bool[mat.Length, mat[0].Length];
                Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
                queue.Enqueue(root);
                int dist = 0;
                while (queue.Count > 0)
                {
                    int count = queue.Count;
                    for (int i = 0; i < count; i++)
                    {
                        var cur = queue.Dequeue();
                        if (mat[cur.r][cur.c] == 0)
                        {
                            return dist;
                        }
                        if (visited[cur.r, cur.c])
                        {
                            continue;
                        }
                        visited[cur.r, cur.c] = true;
                        foreach (var neighbor in neighbors)
                        {
                            int r = cur.r + neighbor.r;
                            int c = cur.c + neighbor.c;
                            if (r >= 0 && r < mat.Length && c >= 0 && c < mat[0].Length)
                            {
                                queue.Enqueue((r, c));
                            }
                        }
                    }
                    dist++;
                }
                return dist;
            }
        }
    }
}
