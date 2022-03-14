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
    }
}
