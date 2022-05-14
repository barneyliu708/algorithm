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

        public class SecondDone
        {
            public class TicTacToe
            {

                private int[] rows;
                private int[] cols;
                private int diagonal;
                private int antidiagonal;
                private int n;

                public TicTacToe(int n)
                {
                    rows = new int[n];
                    cols = new int[n];
                    this.n = n;
                }

                public int Move(int row, int col, int player)
                {
                    int val = player == 1 ? 1 : -1;
                    rows[row] += val;
                    cols[col] += val;
                    if (row - col == 0)
                    { // diagonal
                        diagonal += val;
                    }
                    if (row + col == n - 1)
                    { // antidiagonal 
                        antidiagonal += val;
                    }

                    if (rows[row] == n || cols[col] == n || diagonal == n || antidiagonal == n ||
                        rows[row] == -n || cols[col] == -n || diagonal == -n || antidiagonal == -n)
                    {
                        return player;
                    }

                    return 0;
                }
            }
        }
    }
}
