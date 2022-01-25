using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm.CH10_ElementaryDataStructure
{
    class LC073SetMatrixZeroes
    {
        public void SetZeroes(int[][] matrix)
        {

            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (rows.Contains(i) || cols.Contains(j))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }
    }
}
