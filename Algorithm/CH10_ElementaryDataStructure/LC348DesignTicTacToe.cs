using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC348DesignTicTacToe
    {
        public class TicTacToe
        {

            int[] rows;
            int[] cols;
            int diagonal;
            int antidiagonal;

            int size;

            public TicTacToe(int n)
            {
                size = n;
                rows = new int[n];
                cols = new int[n];
                diagonal = 0;
                antidiagonal = 0;
            }

            public int Move(int row, int col, int player)
            {

                int curplayer = player == 1 ? 1 : -1;

                rows[row] += curplayer;
                cols[col] += curplayer;
                if (row == col)
                {
                    diagonal += curplayer;
                }
                if (row + col == size - 1)
                {
                    antidiagonal += curplayer;
                }

                if (Math.Abs(rows[row]) == size ||
                    Math.Abs(cols[col]) == size ||
                    Math.Abs(diagonal) == size ||
                    Math.Abs(antidiagonal) == size)
                {
                    return player;
                }

                return 0;
            }
        }
    }
}
