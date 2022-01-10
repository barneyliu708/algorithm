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
    }
}
