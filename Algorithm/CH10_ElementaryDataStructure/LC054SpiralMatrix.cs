using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC054SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            int VISITED = 101;
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[][] directions = new int[][] { new[] { 0, 1 }, new[] { 1, 0 }, new[] { 0, -1 }, new[] { -1, 0 } };

            int curDirection = 0;
            int directionChanges = 0;
            int row = 0;
            int col = 0;
            List<int> ans = new List<int>();
            ans.Add(matrix[0][0]);
            matrix[0][0] = VISITED;
            while (directionChanges < 2)
            {
                while (row + directions[curDirection][0] >= 0 && row + directions[curDirection][0] < m &&
                       col + directions[curDirection][1] >= 0 && col + directions[curDirection][1] < n &&
                       matrix[row + directions[curDirection][0]][col + directions[curDirection][1]] != VISITED)
                {
                    row = row + directions[curDirection][0];
                    col = col + directions[curDirection][1];
                    ans.Add(matrix[row][col]);
                    matrix[row][col] = VISITED;
                    directionChanges = 0;
                }
                curDirection = (curDirection + 1) % 4;
                directionChanges++; // only for the last element, its direction changes will be more than 1, which is a sign to stop the loop 
            }

            return ans;
        }

        public class SecondDone
        {
            public IList<int> SpiralOrder(int[][] matrix)
            {
                List<int> ans = new List<int>();
                bool[,] visited = new bool[matrix.Length, matrix[0].Length];

                int total = matrix.Length * matrix[0].Length;
                (int i, int j) index = (0, -1);
                while (ans.Count < total)
                {
                    index.j = MoveRight(matrix, visited, index.i, index.j + 1, ans);

                    index.i = MoveDown(matrix, visited, index.i + 1, index.j, ans);

                    index.j = MoveLeft(matrix, visited, index.i, index.j - 1, ans);

                    index.i = MoveUp(matrix, visited, index.i - 1, index.j, ans);

                }
                return ans;
            }

            private int MoveRight(int[][] matrix, bool[,] visited, int i, int j, List<int> ans)
            {
                int c = j;
                for (; c < matrix[0].Length; c++)
                {
                    if (visited[i, c])
                    {
                        break;
                    }
                    visited[i, c] = true;

                    ans.Add(matrix[i][c]);
                }
                return c - 1; // return the last valid indice
            }

            private int MoveDown(int[][] matrix, bool[,] visited, int i, int j, List<int> ans)
            {
                int r = i;
                for (; r < matrix.Length; r++)
                {
                    if (visited[r, j])
                    {
                        break;
                    }
                    visited[r, j] = true;

                    ans.Add(matrix[r][j]);
                }
                return r - 1; // return the last valid indice
            }

            private int MoveLeft(int[][] matrix, bool[,] visited, int i, int j, List<int> ans)
            {
                int c = j;
                for (; c >= 0; c--)
                {
                    if (visited[i, c])
                    {
                        break;
                    }
                    visited[i, c] = true;

                    ans.Add(matrix[i][c]);
                }
                return c + 1; // return the last valid indice
            }

            private int MoveUp(int[][] matrix, bool[,] visited, int i, int j, List<int> ans)
            {
                int r = i;
                for (; r >= 0; r--)
                {
                    if (visited[r, j])
                    {
                        break;
                    }
                    visited[r, j] = true;

                    ans.Add(matrix[r][j]);
                }
                return r + 1; // return the last valid indice
            }
        }
    }
}
