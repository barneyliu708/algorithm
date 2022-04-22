using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    public class LC130SurroundedRegions
    {
        public void Solve(char[][] board)
        {

            int ROW = board.Length;
            int COL = board[0].Length;

            List<int[]> border = new List<int[]>();
            for (int i = 0; i < ROW; i++)
            {
                border.Add(new int[] { i, 0 });
                border.Add(new int[] { i, COL - 1 });
            }
            for (int i = 0; i < COL; i++)
            {
                border.Add(new int[] { 0, i });
                border.Add(new int[] { ROW - 1, i });
            }

            foreach (int[] node in border)
            {
                Dft(board, node[0], node[1]);
            }

            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    if (board[i][j] == 'O')
                    {
                        board[i][j] = 'X';
                    }
                    if (board[i][j] == 'E')
                    {
                        board[i][j] = 'O';
                    }
                }
            }
        }

        private void Dft(char[][] board, int row, int col)
        {

            if (row < 0 || row >= board.Length ||
                col < 0 || col >= board[0].Length)
            {
                return;
            }

            if (board[row][col] == 'X' || board[row][col] == 'E')
            {
                return;
            }

            board[row][col] = 'E';
            Dft(board, row - 1, col);
            Dft(board, row + 1, col);
            Dft(board, row, col - 1);
            Dft(board, row, col + 1);

        }

        public class BFTApproach
        {
            public void Solve(char[][] board)
            {
                int m = board.Length;
                int n = board[0].Length;

                // generate all borders node
                List<int[]> borders = new List<int[]>();
                for (int i = 0; i < m; i++)
                {
                    borders.Add(new int[] { i, 0 });
                    borders.Add(new int[] { i, n - 1 });
                }
                for (int j = 0; j < n; j++)
                {
                    borders.Add(new int[] { 0, j });
                    borders.Add(new int[] { m - 1, j });
                }

                // scan the border nodes
                foreach (int[] b in borders)
                {
                    if (board[b[0]][b[1]] == 'O')
                    {
                        // breadth-first traversal to mark the node
                        Queue<int[]> queue = new Queue<int[]>();
                        queue.Enqueue(b);

                        while (queue.Count > 0)
                        {
                            int[] cur = queue.Dequeue();
                            if (cur[0] < 0 || cur[0] >= m || cur[1] < 0 || cur[1] >= n || board[cur[0]][cur[1]] != 'O')
                            {
                                continue;
                            }
                            board[cur[0]][cur[1]] = 'E';
                            queue.Enqueue(new int[] { cur[0] - 1, cur[1] });
                            queue.Enqueue(new int[] { cur[0] + 1, cur[1] });
                            queue.Enqueue(new int[] { cur[0], cur[1] - 1 });
                            queue.Enqueue(new int[] { cur[0], cur[1] + 1 });
                        }
                    }
                }

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (board[i][j] == 'O')
                        {
                            board[i][j] = 'X';
                        }
                        if (board[i][j] == 'E')
                        {
                            board[i][j] = 'O';
                        }
                    }
                }
            }
        }
    }
}
