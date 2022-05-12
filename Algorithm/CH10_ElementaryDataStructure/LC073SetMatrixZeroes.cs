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

        public class SecondDone
        {
            public void SetZeroes(int[][] matrix)
            {
                int m = matrix.Length;
                int n = matrix[0].Length;
                bool isFirstCol = false;
                for (int i = 0; i < m; i++)
                {
                    if (matrix[i][0] == 0)
                    {
                        isFirstCol = true;
                    }
                    for (int j = 1; j < n; j++)
                    {
                        if (matrix[i][j] == 0)
                        {
                            matrix[i][0] = 0;
                            matrix[0][j] = 0;
                        }
                    }
                }
                for (int i = 1; i < m; i++)
                {
                    for (int j = 1; j < n; j++)
                    {
                        if (matrix[i][0] == 0 || matrix[0][j] == 0)
                        {
                            matrix[i][j] = 0;
                        }
                    }
                }
                if (matrix[0][0] == 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[0][j] = 0;
                    }
                }
                if (isFirstCol)
                {
                    for (int i = 0; i < m; i++)
                    {
                        matrix[i][0] = 0;
                    }
                }
            }
        }
    }
}
