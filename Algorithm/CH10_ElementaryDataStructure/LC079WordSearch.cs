using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.CH10_ElementaryDataStructure
{
    internal class LC079WordSearch
    {
        public bool Exist(char[][] board, string word)
        {

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (Exist(board, word, i, j, 0))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool Exist(char[][] board, string word, int i, int j, int w)
        {

            if (w >= word.Length)
            {
                return true;
            }

            if (i < 0 || i >= board.Length ||
                j < 0 || j >= board[0].Length)
            {
                return false;
            }

            if (board[i][j] == '#')
            {
                return false;
            }

            if (board[i][j] != word[w])
            {
                return false;
            }


            board[i][j] = '#'; // mark the element as visited

            bool ans = Exist(board, word, i + 1, j, w + 1) ||
                       Exist(board, word, i - 1, j, w + 1) ||
                       Exist(board, word, i, j + 1, w + 1) ||
                       Exist(board, word, i, j - 1, w + 1);

            board[i][j] = word[w];

            return ans;
        }
    }
}
