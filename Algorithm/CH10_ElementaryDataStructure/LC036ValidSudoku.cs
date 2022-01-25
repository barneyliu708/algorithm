using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC036ValidSudoku
    {
        public bool IsValidSudoku(char[][] board)
        {

            int N = 9;

            HashSet<char>[] rows = new HashSet<char>[N];
            HashSet<char>[] cols = new HashSet<char>[N];
            HashSet<char>[] boxes = new HashSet<char>[N];

            for (int i = 0; i < N; i++)
            {
                rows[i] = new HashSet<char>();
                cols[i] = new HashSet<char>();
                boxes[i] = new HashSet<char>();
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    char val = board[i][j];

                    if (val == '.')
                    {
                        continue;
                    }

                    if (rows[i].Contains(val))
                    {
                        return false;
                    }
                    rows[i].Add(val);

                    if (cols[j].Contains(val))
                    {
                        return false;
                    }
                    cols[j].Add(val);

                    int idx = (i / 3) * 3 + j / 3;
                    if (boxes[idx].Contains(val))
                    {
                        return false;
                    }
                    boxes[idx].Add(val);

                }
            }

            return true;
        }
    }
}
